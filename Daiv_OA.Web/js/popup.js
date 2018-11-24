/********************************************************************************************
* Create:  Alpha
* DateTime: 2008-4-15
* Reloading Method
* Popup Window Type: iframe, prompt, confirm, alert,warning
*
* Joseph（二次修正）：弹出居中（横向居中未尝试）、火狐兼容
* Joseph（第三次修正）：新增加warning（title,content,width,height）模式（无关闭按钮）
* Alpha(第四次修正)：新增URL跳转功能，用于点击“确定”按钮进行URL跳转
* Joseph（第五次修正）：新增加warning 可设置边框颜色（title,content,width,height,bodercolor）模式（无关闭按钮）
*                                      在第四次修正上追加关闭按钮事件，如果存在URL跳转请求，则无论是点击确定还是关闭按钮都将跳转
*Joseph（第六次修正）：增加支持确定按钮、关闭按钮简易自定义事件的 alertCallBack（title,contents,OKaction,CloseAction）模式。两个action均为字串，系统会通过eval来调用
*Joseph（第七次修正）：修护多次调用弹出命令时的bug。bug描述：多次调用时，在其第一次时会将页面上的元素（select 等）隐藏，并将这些信息保存在类变量中，如果在其为人工点击或触发close事件时
*                                     再次调用弹出命令，这些隐藏元素信息将丢失（因为会从新new一个对象出来）。待结束时也不会恢复显示。故此增加了两个全局变量用来保存这些信息。
*Joseph (第八次修正)：  由于系统会自动隐藏掉select,object等标签元素，有时候由于需要 必须禁止隐藏页面中的某些select 例如弹出框中的select，则可以给其添加一个 HideIt 属性并设置为"None"
********************************************************************************************/
var globalsomeToDIsabled=[];
var globalsomeToHidden=[];
var setIntTop=0;
var setIntLeft=0;

// 以上为两个全局变量 用来存放 隐藏元素
function addMethod(object, name, fn) {
    var old = object[name];
    object[name] = function() {
        if (fn.length == arguments.length) {
            return fn.apply(this, arguments);
        }
        else if (typeof old == 'function') {
            return old.apply(this, arguments);
        }
    }
};
var g_pop = null;

var PopWindow = function() {
    g_pop = null;

    addMethod(this, "iframe",
    function(title, content, isreload, widths, heights) {
        g_pop = null;
        g_pop = new Popup({
            contentType: 1,
            isReloadOnClose: isreload,
            width: widths,
            height: heights
        });
        g_pop.setContent("title", title);
        g_pop.setContent("contentUrl", content);
        g_pop.build();
        g_pop.show();
    });

    //Joseph 扩展方法 warning 没有关闭按钮 title  标题 content 内容 widths 宽度 heights 高度
    addMethod(this, "warning",
    function(title, content, widths, heights) {
        g_pop = null;
        g_pop = new Popup({
            contentType: 2,
            isReloadOnClose: false,
            width: widths,
            height: heights
        });
        g_pop.color.tColor = "red";
        g_pop.setContent("canclose", "false");
        g_pop.setContent("title", title);
        g_pop.setContent("contentHtml", content);
        g_pop.build();
        g_pop.show();

    });
    
     //Joseph 扩展方法 warning 没有关闭按钮 title  标题 content 内容 widths 宽度 heights 高度 color色彩
     addMethod(this, "warning",
    function(title, content, widths, heights,color) {
        g_pop = null;
        g_pop = new Popup({
            contentType: 2,
            isReloadOnClose: false,
            width: widths,
            height: heights
        });
        g_pop.color.tColor = color;
        g_pop.setContent("canclose", "false");
        g_pop.setContent("title", title);
        g_pop.setContent("contentHtml", content);
        g_pop.build();
        g_pop.show();

    });

    addMethod(this, "prompt",
    function(title, content, isreload, widths, heights) {
        g_pop = null;
        g_pop = new Popup({
            contentType: 2,
            isReloadOnClose: isreload,
            width: widths,
            height: heights
        });
        g_pop.setContent("title", title);
        g_pop.setContent("contentHtml", content);
        g_pop.build();
        g_pop.show();
    });

    addMethod(this, "confirm",
    function(title, content, isreload, widths, heights) {
        g_pop = null;
        g_pop = new Popup({
            contentType: 3,
            isReloadOnClose: isreload,
            width: widths,
            height: heights
        });
        g_pop.setContent("title", title);
        g_pop.setContent("confirmCon", content);
        //g_pop.setContent("callBack",delCallback); 回调函数delCallback
        //pop.setContent("parameter",{fid:str,popup:pop}); 参数：值 fid:str
        g_pop.build();
        g_pop.show();
        return false;
    });

    addMethod(this, "alert",
    function(content) {
        g_pop = null;
        g_pop = new Popup({
            contentType: 4,
            isReloadOnClose: false,
            width: 300,
            height: 100
        });
        g_pop.setContent("title", "远程教育管理平台");
        g_pop.setContent("alertCon", content);
        g_pop.build();
        g_pop.show();
    });
    
    
     addMethod(this,"alert",
    function(content,urltransfer){
        g_pop = null;
        g_pop = new Popup({
            contentType: 4,
            isReloadOnClose: false,
            width: 300,
            height: 100,
            urltransfer: urltransfer
        });
        g_pop.setContent("title", "远程教育系统提示");
        g_pop.setContent("alertCon", content);
        g_pop.build();
        g_pop.show();
    });
    addMethod(this, "alert",
    function(title,content, isreload) {
        g_pop = null;
        g_pop = new Popup({
            contentType: 4,
            isReloadOnClose: isreload,
            width: 300,
            height: 100
        });
        g_pop.setContent("title", title);
        g_pop.setContent("alertCon", content);
        g_pop.build();
        g_pop.show();
    });
    
     addMethod(this, "alertCallBack",
    function(title,content, okaction,closeaction) {
        g_pop = null;
        g_pop = new Popup({
            contentType: 4,
            isReloadOnClose: false,
            width: 300,
            height: 100
        });
        g_pop.setContent("title", title);
        g_pop.setContent("alertCon", content);
        g_pop.setContent("closeaction", closeaction);
        g_pop.setContent("okaction", okaction);
        g_pop.build();
        g_pop.show();
    });
    
    addMethod(this, "alert",
    function(content, isreload, widths, heights) {
        g_pop = null;
        g_pop = new Popup({
            contentType: 4,
            isReloadOnClose: isreload,
            width: widths,
            height: heights
        });
        g_pop.setContent("title", "远程教育系统提示");
        g_pop.setContent("alertCon", content);
        g_pop.build();
        g_pop.show();
    });
    addMethod(this, "alert",
    function(title, content, isreload, widths, heights) {
        g_pop = null;
        g_pop = new Popup({
            contentType: 4,
            isReloadOnClose: isreload,
            width: widths,
            height: heights
        });
        g_pop.setContent("title", title);
        g_pop.setContent("alertCon", content);
        g_pop.build();
        g_pop.show();
    });

    addMethod(this, "close",
    function() {
        if (g_pop != null) {
            g_pop.reset();
        }
    });
};
/********************************************
* http://hi.baidu.com javascript library
* Trimmer:  Alpha
* DateTime: 2008-4-15
* Popup Window Type: iframe, prompt, confirm, alert
********************************************/
//if (!Array.prototype.push) {
//    Array.prototype.push = function() {
//        var startLength = this.length;
//        for (var i = 0; i < arguments.length; i++)
//        this[startLength + i] = arguments[i];
//        return this.length
//    }
//};

function G() {
    var elements = new Array();
    for (var i = 0; i < arguments.length; i++) {
        var element = arguments[i];
        if (typeof element == 'string') element = document.getElementById(element);
        if (arguments.length == 1) return element;
        elements.push(element)
    };
    return elements
};

//Function.prototype.bind = function(object) {
//    var __method = this;
//    return function() {
//        __method.apply(object, arguments)
//    }
//};

//Function.prototype.bindAsEventListener = function(object) {
//    var __method = this;
//    return function(event) {
//        __method.call(object, event || window.event)
//    }
//};

Object.extend = function(destination, source) {
    for (property in source) {
        destination[property] = source[property]
    };
    return destination
};

if (!window.Event) {
    var Event = new Object()
};

Object.extend(
Event, {
    observers: false,
    element: function(event) {
        return event.target || event.srcElement
    },
    isLeftClick: function(event) {
        return (((event.which) && (event.which == 1)) || ((event.button) && (event.button == 1)))
    },
    pointerX: function(event) {
        return event.pageX || (event.clientX + (document.documentElement.scrollLeft || document.body.scrollLeft))
    },
    pointerY: function(event) {
        return event.pageY || (event.clientY + (document.documentElement.scrollTop || document.body.scrollTop))
    },
    stop: function(event) {
        if (event.preventDefault) {
            event.preventDefault();
            event.stopPropagation()
        }
        else {
            event.returnValue = false;
            event.cancelBubble = true
        }
    },
    findElement: function(event, tagName) {
        var element = Event.element(event);
        while (element.parentNode && (!element.tagName || (element.tagName.toUpperCase() != tagName.toUpperCase())))
        element = element.parentNode;
        return element
    },
    _observeAndCache: function(element, name, observer, useCapture) {
        if (!this.observers) this.observers = [];
        if (element.addEventListener) {
            this.observers.push([element, name, observer, useCapture]);
            element.addEventListener(name, observer, useCapture)
        }
        else if (element.attachEvent) {
            this.observers.push([element, name, observer, useCapture]);
            element.attachEvent('on' + name, observer)
        }
    },
    unloadCache: function() {
        if (!Event.observers) return;
        for (var i = 0; i < Event.observers.length; i++) {
            Event.stopObserving.apply(this, Event.observers[i]);
            Event.observers[i][0] = null
        };
        Event.observers = false
    },
    observe: function(element, name, observer, useCapture) {
        var element = G(element);
        useCapture = useCapture || false;
        if (name == 'keypress' && (navigator.appVersion.match(/Konqueror|Safari|KHTML/) || element.attachEvent)) name = 'keydown';
        this._observeAndCache(element, name, observer, useCapture)
    },
    stopObserving: function(element, name, observer, useCapture) {
        var element = G(element);
        useCapture = useCapture || false;
        if (name == 'keypress' && (navigator.appVersion.match(/Konqueror|Safari|KHTML/) || element.detachEvent)) name = 'keydown';
        if (element.removeEventListener) {
            element.removeEventListener(name, observer, useCapture)
        }
        else if (element.detachEvent) {
            element.detachEvent('on' + name, observer)
        }
    }
});

Event.observe(window, 'unload', Event.unloadCache, false);

var Class = function() {
    var _class = function() {
        this.initialize.apply(this, arguments)
    };
    for (i = 0; i < arguments.length; i++) {
        superClass = arguments[i];
        for (member in superClass.prototype) {
            _class.prototype[member] = superClass.prototype[member]
        }
    };
    _class.child = function() {
        return new Class(this)
    };
    _class.extend = function(f) {
        for (property in f) {
            _class.prototype[property] = f[property]
        }
    };
    return _class
};
function getRootPath(){ 
var strFullPath=window.document.location.href; 
var strPath=window.document.location.pathname; 
var pos=strFullPath.indexOf(strPath); 
var prePath=strFullPath.substring(0,pos); 
var postPath=strPath.substring(0,strPath.substr(1).indexOf('/')+1); 
return(prePath+postPath); 
} ;

function space(flag) {
    if (flag == "begin") {
        var ele = document.getElementById("ft");
        if (typeof(ele) != "undefined" && ele != null) ele.id = "ft_popup";
        ele = document.getElementById("usrbar");
        if (typeof(ele) != "undefined" && ele != null) ele.id = "usrbar_popup"
    }
    else if (flag == "end") {
        var ele = document.getElementById("ft_popup");
        if (typeof(ele) != "undefined" && ele != null) ele.id = "ft";
        ele = document.getElementById("usrbar_popup");
        if (typeof(ele) != "undefined" && ele != null) ele.id = "usrbar"
    }
};

var Popup = new Class();
Popup.prototype = {
    iframeIdName: 'ifr_popup',
    initialize: function(config) {
        this.config = Object.extend({
            contentType: 1,
            isHaveTitle: true,
            scrollType: 'no',
            isBackgroundCanClick: false,
            isSupportDraging: true,
            isShowShadow: true,
            isReloadOnClose: true,
            width: 400,
            height: 250,
            lwidth: 400,
            lheight: 150,
            canclose: "true",
            okaction:"",
            closeaction:"",
            urltransfer: '' // Alpha修改：URL跳转地址 08-12-15
        },
        config || {});
        this.info = {
            shadowWidth: 4,
            title: "",
            contentUrl: "",
            contentHtml: "",
            callBack: null,
            parameter: null,
            confirmCon: "",
            alertCon: "",
            someHiddenTag: "select,object,embed",
            someDisabledBtn: "",
            someHiddenEle: "",
            overlay: 0,
            coverOpacity: 40
        
        };
        this.color = {
            cColor: "#CCCCCC",
            bColor: "#FFFFFF",
            tColor: "#709CD2",
            wColor: "#FFFFFF"
        };
        this.dropClass = null;
        this.someToHidden = [];
        this.someToDisabled = [];
        if (!this.config.isHaveTitle) this.config.isSupportDraging = false;
        this.iniBuild()
    },
    setContent: function(arrt, val) {
        if (val != '') {
            switch (arrt) {
            case 'width':
                this.config.width = val;
                break;
            case 'height':
                this.config.height = val;
                break;
            case 'canclose':
                this.config.canclose = val;
                break;
            case 'closeaction':
               this.config.closeaction=val;
               break;
            case 'okaction':
               this.config.okaction=val;
               break;
            case 'lwidth':
                this.config.lwidth = val;
                break;
            case 'lheight':
                this.config.lheight = val;
                break;
                // Alpha修改：URL跳转地址 08-12-15
            case 'urltransfer':
                this.config.urltransfer = val;
                break;
            case 'title':
                this.info.title = val;
                break;
            case 'contentUrl':
                this.info.contentUrl = val;
                break;
            case 'contentHtml':
                this.info.contentHtml = val;
                break;
            case 'callBack':
                this.info.callBack = val;
                break;
            case 'parameter':
                this.info.parameter = val;
                break;
                //选择类型的内容
            case 'confirmCon':
                this.info.confirmCon = val;
                break;
                //警示类型的内容
            case 'alertCon':
                this.info.alertCon = val;
                break;
            case 'someHiddenTag':
                this.info.someHiddenTag = val;
                break;
            case 'someHiddenEle':
                this.info.someHiddenEle = val;
                break;
            case 'someDisabledBtn':
                this.info.someDisabledBtn = val;
                break;
            case 'overlay':
                this.info.overlay = val;
                break;
            }
        }
    },
  
    iniBuild: function() {
        G('dialogCase') ? G('dialogCase').parentNode.removeChild(G('dialogCase')) : function() {};
        var oDiv = document.createElement('span');
        oDiv.id = 'dialogCase';
        document.body.appendChild(oDiv);
    },
    build: function() {
        var baseZIndex = 10001 + this.info.overlay * 10;
        var showZIndex = baseZIndex + 2;
       this.iframeIdName = 'ifr_popup' + this.info.overlay;
   var path = "/images/"; //定义图片路径
  
        var close = "";
        if (this.config.canclose == "true")
         {  /// <reference path="" />
           close = '<input type="image"  id="dialogBoxClose" src="' + path + 'dialogclose.gif" border="0" width="16" height="16" align="absmiddle" title="关闭"/>';
        }
        else {
           close = '<input type="image" id="dialogBoxClose" src="' + path + 'dialogclose.gif" border="0" width="16" height="16" align="absmiddle" title="关闭" style="display:none;"/>';
        }
        var cB = 'filter: alpha(opacity=' + this.info.coverOpacity + ');opacity:' + this.info.coverOpacity / 100 + ';';
        var cover = '<div id="dialogBoxBG" style="position:absolute;top:0px;left:0px;width:100%;height:100%;z-index:' + baseZIndex + ';' + cB + 'background-color:' + this.color.cColor + ';display:none;"></div>';
        var mainBox = '<div id="dialogBox" style="border:1px solid ' + this.color.tColor + ';display:none;z-index:' + showZIndex + ';position:relative;width:' + this.config.width + 'px;"><table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="' + this.color.bColor + '">';
        if (this.config.isHaveTitle) {
            mainBox += '<tr height="24" bgcolor="' + this.color.tColor + '"><td><table style="-moz-user-select:none;height:24px;" width="100%" border="0" cellpadding="0" cellspacing="0" ><tr>' + '<td width="6" height="24"></td><td id="dialogBoxTitle" style="color:' + this.color.wColor + ';font-size:14px;font-weight:bold;">' + this.info.title + '&nbsp;</td>' + '<td id="dialogClose" width="20" align="right" valign="middle">' + close + '</td><td width="6"></td></tr></table></td></tr>'
        }
        else {
            mainBox += '<tr height="10"><td align="right">' + close + '</td></tr>'
        };
        mainBox += '<tr style="height:' + this.config.height + 'px;" valign="top"><td id="dialogBody" style="position:relative;"></td></tr></table></div>' + '<div id="dialogBoxShadow" style="display:none;z-index:' + baseZIndex + ';"></div>';
        if (!this.config.isBackgroundCanClick) {
            G('dialogCase').innerHTML = cover + mainBox;
            //G('dialogBoxBG').style.height = document.body.scrollHeight+"px"
            //Joseph 修改，使其在页面宽度不够的时候也能够 遮盖整个页面
            G('dialogBoxBG').style.height = getPos() + (document.body.scrollHeight < window.screen.availHeight ? window.screen.availHeight: document.body.scrollHeight )+ "px";
        }
        else G('dialogCase').innerHTML = mainBox;
        Event.observe(
        G('dialogBoxClose'), "click", this.reset.bindAsEventListener(this), false);
        
       // Event.observe(G('dialogBoxBG'), "click", this.reset.bindAsEventListener(this), false);
        
        if (this.config.isSupportDraging) {
            dropClass = new Dragdrop(
            this.config.width, this.config.height, this.info.shadowWidth, this.config.isSupportDraging, this.config.contentType);
            G("dialogBoxTitle").style.cursor = "move"
        };
        this.lastBuild()
    },
    lastBuild: function() {
        var baseZIndex = 10001 + this.info.overlay * 10;
        var coverIfZIndex = baseZIndex + 4;
        //判断提示框类型
        if (this.config.contentType == 1) {
            //iFrame类型
            var openIframe = "<iframe width='100%' style='height:" + this.config.height + "px' name='" + this.iframeIdName + "' id='" + this.iframeIdName + "' src='" + this.info.contentUrl + "' frameborder='0' scrolling='" + this.config.scrollType + "'></iframe>";
            var coverIframe = "<div id='iframeBG' style='position:absolute;top:0px;left:0px;width:1px;height:1px;z-index:" + coverIfZIndex + ";filter: alpha(opacity=00);opacity:0.00;background-color:#ffffff;'><div>";
            G("dialogBody").innerHTML = openIframe + coverIframe
        }
        else if (this.config.contentType == 2) {
            //提示类型 修改者：Alpha 修改时间：081202
            G("dialogBody").innerHTML = '<div style="width:100%;height:100%;background: url(../images/popup/s_bg.jpg) no-repeat right  tom;"><div style="margin:10px;font-size:14px;">' + this.info.contentHtml + '</div></div>';
          
        }
        else if (this.config.contentType == 3) {
            //选择类型 修改者：Alpha 修改时间：081202
            G("dialogBody").innerHTML = '<div style="width:100%;height:100%;background: url(../images/popup/p_bg.jpg) no-repeat right  tom;"><div style="margin:10px;font-size:14px;">' + this.info.confirmCon + '</div><div style="margin:20px;text-align:center;"><input id="dialogOk" type="button" value="  确定  "/>&nbsp;<input id="dialogCancel" type="button" value="  取消  "/></div></div>';
            Event.observe(G('dialogOk'), "click", this.forCallback.bindAsEventListener(this), false);
            Event.observe(G('dialogCancel'), "click", this.close.bindAsEventListener(this), false)
        }
        else if (this.config.contentType == 4) {
            //警示类型 修改者：Alpha 修改时间：081202
            G("dialogBody").innerHTML = '<div style="width:100%;height:100%;background: url(../images/popup/w_bg.jpg) no-repeat right  tom;"><div style="margin:10px;font-size:14px;">' + this.info.alertCon + '</div><div style="margin:20px;text-align:center;"><input id="dialogYES" type="button" value="  确定  "/></div></div>';
            // 判断是否做URL跳转 Alpha 081215
 
            if(this.config.okaction!=""&&this.config.okaction!=undefined ){
             Event.observe(G('dialogYES'), "click", this.okClick.bindAsEventListener(this), false);
           
            }else{
             if (this.config.urltransfer == ''){
                Event.observe(G('dialogYES'), "click", this.reset.bindAsEventListener(this), false);
                 
            }
            else{
                Event.observe(G('dialogYES'), "click", this.urltransfer.bindAsEventListener(this), false);
                Event.observe(G('dialogBoxClose'), "click",this.urltransfer.bindAsEventListener(this), false);
                
            }
            }
        }
    },
    reBuild: function() {
        G('dialogBody').height = G('dialogBody').clientHeight;
        this.lastBuild()
    },
    show: function() {
        this.hiddenSome();
        this.middle();
        if (this.config.isShowShadow) this.shadow()
    },
    forCallback: function() {
        return this.info.callBack(this.info.parameter)
    },
    shadow: function() {
        var oShadow = G('dialogBoxShadow');
        var oDialog = G('dialogBox');
        oShadow['style']['position'] = "absolute";
        oShadow['style']['background'] = "#000";
        oShadow['style']['display'] = "";
        oShadow['style']['opacity'] = "0.2";
        oShadow['style']['filter'] = "alpha(opacity=20)";
        oShadow['style']['top'] = oDialog.offsetTop + this.info.shadowWidth + "px";
        
        oShadow['style']['left'] = oDialog.offsetLeft + this.info.shadowWidth + "px";
        
        oShadow['style']['width'] = oDialog.offsetWidth + "px";
        oShadow['style']['height'] = oDialog.offsetHeight + "px"
    },
    middle: function() {
        if (!this.config.isBackgroundCanClick) G('dialogBoxBG').style.display = '';
        var oDialog = G('dialogBox');
        oDialog['style']['position'] = "absolute";
        oDialog['style']['display'] = '';
        var sClientWidth = this.config.lwidth + "px";
        var sClientHeight = this.config.lheight + "px";

        var sleft = (window.top.document.body.clientWidth / 2) - (oDialog.offsetWidth / 2)-setIntLeft;
        //Joseph 更改其距离top的位置
        var sTop = (getPos() + screen.availHeight / 2 - this.config.lheight / 2) - (oDialog.offsetHeight / 2);

        if (sTop < 1) sTop = "20";
        if (sleft < 1) sleft = "20";
        oDialog['style']['left'] = sleft + "px";
        oDialog['style']['top'] = sTop + "px";
        
    },
    reset: function() {
        if (this.config.isReloadOnClose) {
            top.location.reload()
        };
        if(this.config.canclose=="true"&&this.config.closeaction!=""){
         this.close();
         eval(this.config.closeaction);
        return true;
        };
        this.close();
          //this.showSome()
    },
    // URL跳转方法——Alpha 081215
    urltransfer: function(){
        if (this.config.urltransfer != ''){
            top.location.href = this.config.urltransfer;
        };
    },
    okClick:function(){
         this.close();
        eval(this.config.okaction);
       
    },
    close: function() {
        G('dialogBox').style.display = 'none';
        if (!this.config.isBackgroundCanClick) G('dialogBoxBG').style.display = 'none';
        if (this.config.isShowShadow) G('dialogBoxShadow').style.display = 'none';
        G('dialogBody').innerHTML = '';
        this.showSome()
    },
    hiddenSome: function() {
        var tag = this.info.someHiddenTag.split(",");
        if (tag.length == 1 && tag[0] == "") tag.length = 0;
        for (var i = 0; i < tag.length; i++) {
            this.hiddenTag(tag[i])
        };
        var ids = this.info.someHiddenEle.split(",");
        if (ids.length == 1 && ids[0] == "") ids.length = 0;
        for (var i = 0; i < ids.length; i++) {
            this.hiddenEle(ids[i])
        };
        var ids = this.info.someDisabledBtn.split(",");
        if (ids.length == 1 && ids[0] == "") ids.length = 0;
        for (var i = 0; i < ids.length; i++) {
            this.disabledBtn(ids[i])
        };
        space("begin")
    },
    disabledBtn: function(id) {
        var ele = document.getElementById(id);
        if (typeof(ele) != "undefined" && ele != null && ele.disabled == false) {
            ele.disabled = true;
            this.someToDisabled.push(ele);
            globalsomeToDIsabled.push(ele);
        }
    },
    hiddenTag: function(tagName) {
        var ele = document.getElementsByTagName(tagName);
        if (ele != null) {
            for (var i = 0; i < ele.length; i++) {
                if (ele[i].style.display != "none" && ele[i].style.visibility != 'hidden'&&ele[i].getAttribute('HideIt')!='None') {
                    ele[i].style.visibility = 'hidden';
                    this.someToHidden.push(ele[i]);
                    globalsomeToHidden.push(ele[i]);
                  
                }
            }
        }
    },
    hiddenEle: function(id) {
        var ele = document.getElementById(id);
        if (typeof(ele) != "undefined" && ele != null) {
            ele.style.visibility = 'hidden';
            this.someToHidden.push(ele);
             globalsomeToHidden.push(ele);
        }
    },
    showSome: function() {
   
//        for (var i = 0; i < this.someToHidden.length; i++) {
//            this.someToHidden[i].style.visibility = 'visible'
//        };
//        for (var i = 0; i < this.someToDisabled.length; i++) {
//            this.someToDisabled[i].disabled = false
//        };

  for (var i = 0; i < globalsomeToHidden.length; i++) {
            globalsomeToHidden[i].style.visibility = 'visible'
        };
        for (var i = 0; i < globalsomeToDIsabled.length; i++) {
           globalsomeToDIsabled[i].disabled = false
        };
        space("end")
    
    }
};
var Dragdrop = new Class();
Dragdrop.prototype = {
    initialize: function(width, height, shadowWidth, showShadow, contentType) {
        this.dragData = null;
        this.dragDataIn = null;
        this.backData = null;
        this.width = width;
        this.height = height;
        this.shadowWidth = shadowWidth;
        this.showShadow = showShadow;
        this.contentType = contentType;
        this.IsDraging = false;
        this.oObj = G('dialogBox');
        Event.observe(
        G('dialogBoxTitle'), "mousedown", this.moveStart.bindAsEventListener(this), false)
    },
    moveStart: function(event) {
        this.IsDraging = true;
        if (this.contentType == 1) {
            G("iframeBG").style.display = "";
            G("iframeBG").style.width = this.width + "px";
            G("iframeBG").style.height = this.height + "px"
        };
        Event.observe(document, "mousemove", this.mousemove.bindAsEventListener(this), false);
        Event.observe(document, "mouseup", this.mouseup.bindAsEventListener(this), false);
        Event.observe(document, "selectstart", this.returnFalse, false);
        this.dragData = {
            x: Event.pointerX(event),
            y: Event.pointerY(event)
        };
        this.backData = {
            x: parseInt(this.oObj.style.left),
            y: parseInt(this.oObj.style.top)
        }
    },
    mousemove: function(event) {
        if (!this.IsDraging) return;
        var iLeft = Event.pointerX(event) - this.dragData["x"] + parseInt(this.oObj.style.left);
        var iTop = Event.pointerY(event) - this.dragData["y"] + parseInt(this.oObj.style.top);
        if (this.dragData["y"] < parseInt(this.oObj.style.top)) iTop = iTop - 12;
        else if (this.dragData["y"] > parseInt(this.oObj.style.top) + 25) iTop = iTop + 12;
        this.oObj.style.left = iLeft + "px";
        this.oObj.style.top = iTop + "px";
        if (this.showShadow) {
            G('dialogBoxShadow').style.left = iLeft + this.shadowWidth + "px";
            G('dialogBoxShadow').style.top = iTop + this.shadowWidth + "px"
        };
        this.dragData = {
            x: Event.pointerX(event),
            y: Event.pointerY(event)
        };
        document.body.style.cursor = "move"
    },
    mouseup: function(event) {
        if (!this.IsDraging) return;
        if (this.contentType == 1) G("iframeBG").style.display = "none";
        document.onmousemove = null;
        document.onmouseup = null;
        var mousX = Event.pointerX(event) - (document.documentElement.scrollLeft || document.body.scrollLeft);
        var mousY = Event.pointerY(event) - (document.documentElement.scrollTop || document.body.scrollTop);
        if (mousX < 1 || mousY < 1 || mousX > document.body.clientWidth || mousY > document.body.clientHeight) {
            this.oObj.style.left = this.backData["x"] + "px";
            this.oObj.style.top = this.backData["y"] + "px";
            if (this.showShadow) {
                G('dialogBoxShadow').style.left = this.backData["x"] + this.shadowWidth + "px";
                G('dialogBoxShadow').style.top = this.backData["y"] + this.shadowWidth + "px"
            }
        };

        this.IsDraging = false;
        document.body.style.cursor = "";
        Event.stopObserving(document, "selectstart", this.returnFalse, false)
    },
    returnFalse: function() {
        return false
    }
    
    
};


//姓名拼音获取

function hash(_key,_value)

{

this.key = _key;

this.value = _value;

}

function dictionary()

{

this.items = [];

this.add = function(_key,_value)

{

   this.items[this.items.length] = new hash(_key,_value);

}

}

var d = new dictionary();

d.add("a",-20319);

d.add("ai",-20317);

d.add("an",-20304);

d.add("ang",-20295);

d.add("ao",-20292);

d.add("ba",-20283);

d.add("bai",-20265);

d.add("ban",-20257);

d.add("bang",-20242);

d.add("bao",-20230);

d.add("bei",-20051);

d.add("ben",-20036);

d.add("beng",-20032);

d.add("bi",-20026);

d.add("bian",-20002);

d.add("biao",-19990);

d.add("bie",-19986);

d.add("bin",-19982);

d.add("bing",-19976);

d.add("bo",-19805);

d.add("bu",-19784);

d.add("ca",-19775);

d.add("cai",-19774);

d.add("can",-19763);

d.add("cang",-19756);

d.add("cao",-19751);

d.add("ce",-19746);

d.add("ceng",-19741);

d.add("cha",-19739);

d.add("chai",-19728);

d.add("chan",-19725);

d.add("chang",-19715);

d.add("chao",-19540);

d.add("che",-19531);

d.add("chen",-19525);

d.add("cheng",-19515);

d.add("chi",-19500);

d.add("chong",-19484);

d.add("chou",-19479);

d.add("chu",-19467);

d.add("chuai",-19289);

d.add("chuan",-19288);

d.add("chuang",-19281);

d.add("chui",-19275);

d.add("chun",-19270);

d.add("chuo",-19263);

d.add("ci",-19261);

d.add("cong",-19249);

d.add("cou",-19243);

d.add("cu",-19242);

d.add("cuan",-19238);

d.add("cui",-19235);

d.add("cun",-19227);

d.add("cuo",-19224);

d.add("da",-19218);

d.add("dai",-19212);

d.add("dan",-19038);

d.add("dang",-19023);

d.add("dao",-19018);

d.add("de",-19006);

d.add("deng",-19003);

d.add("di",-18996);

d.add("dian",-18977);

d.add("diao",-18961);

d.add("die",-18952);

d.add("ding",-18783);

d.add("diu",-18774);

d.add("dong",-18773);

d.add("dou",-18763);

d.add("du",-18756);

d.add("duan",-18741);

d.add("dui",-18735);

d.add("dun",-18731);

d.add("duo",-18722);

d.add("e",-18710);

d.add("en",-18697);

d.add("er",-18696);

d.add("fa",-18526);

d.add("fan",-18518);

d.add("fang",-18501);

d.add("fei",-18490);

d.add("fen",-18478);

d.add("feng",-18463);

d.add("fo",-18448);

d.add("fou",-18447);

d.add("fu",-18446);

d.add("ga",-18239);

d.add("gai",-18237);

d.add("gan",-18231);

d.add("gang",-18220);

d.add("gao",-18211);

d.add("ge",-18201);

d.add("gei",-18184);

d.add("gen",-18183);

d.add("geng",-18181);

d.add("gong",-18012);

d.add("gou",-17997);

d.add("gu",-17988);

d.add("gua",-17970);

d.add("guai",-17964);

d.add("guan",-17961);

d.add("guang",-17950);

d.add("gui",-17947);

d.add("gun",-17931);

d.add("guo",-17928);

d.add("ha",-17922);

d.add("hai",-17759);

d.add("han",-17752);

d.add("hang",-17733);

d.add("hao",-17730);

d.add("he",-17721);

d.add("hei",-17703);

d.add("hen",-17701);

d.add("heng",-17697);

d.add("hong",-17692);

d.add("hou",-17683);

d.add("hu",-17676);

d.add("hua",-17496);

d.add("huai",-17487);

d.add("huan",-17482);

d.add("huang",-17468);

d.add("hui",-17454);

d.add("hun",-17433);

d.add("huo",-17427);

d.add("ji",-17417);

d.add("jia",-17202);

d.add("jian",-17185);

d.add("jiang",-16983);

d.add("jiao",-16970);

d.add("jie",-16942);

d.add("jin",-16915);

d.add("jing",-16733);

d.add("jiong",-16708);

d.add("jiu",-16706);

d.add("ju",-16689);

d.add("juan",-16664);

d.add("jue",-16657);

d.add("jun",-16647);

d.add("ka",-16474);

d.add("kai",-16470);

d.add("kan",-16465);

d.add("kang",-16459);

d.add("kao",-16452);

d.add("ke",-16448);

d.add("ken",-16433);

d.add("keng",-16429);

d.add("kong",-16427);

d.add("kou",-16423);

d.add("ku",-16419);

d.add("kua",-16412);

d.add("kuai",-16407);

d.add("kuan",-16403);

d.add("kuang",-16401);

d.add("kui",-16393);

d.add("kun",-16220);

d.add("kuo",-16216);

d.add("la",-16212);

d.add("lai",-16205);

d.add("lan",-16202);

d.add("lang",-16187);

d.add("lao",-16180);

d.add("le",-16171);

d.add("lei",-16169);

d.add("leng",-16158);

d.add("li",-16155);

d.add("lia",-15959);

d.add("lian",-15958);

d.add("liang",-15944);

d.add("liao",-15933);

d.add("lie",-15920);

d.add("lin",-15915);

d.add("ling",-15903);

d.add("liu",-15889);

d.add("long",-15878);

d.add("lou",-15707);

d.add("lu",-15701);

d.add("lv",-15681);

d.add("luan",-15667);

d.add("lue",-15661);

d.add("lun",-15659);

d.add("luo",-15652);

d.add("ma",-15640);

d.add("mai",-15631);

d.add("man",-15625);

d.add("mang",-15454);

d.add("mao",-15448);

d.add("me",-15436);

d.add("mei",-15435);

d.add("men",-15419);

d.add("meng",-15416);

d.add("mi",-15408);

d.add("mian",-15394);

d.add("miao",-15385);

d.add("mie",-15377);

d.add("min",-15375);

d.add("ming",-15369);

d.add("miu",-15363);

d.add("mo",-15362);

d.add("mou",-15183);

d.add("mu",-15180);

d.add("na",-15165);

d.add("nai",-15158);

d.add("nan",-15153);

d.add("nang",-15150);

d.add("nao",-15149);

d.add("ne",-15144);

d.add("nei",-15143);

d.add("nen",-15141);

d.add("neng",-15140);

d.add("ni",-15139);

d.add("nian",-15128);

d.add("niang",-15121);

d.add("niao",-15119);

d.add("nie",-15117);

d.add("nin",-15110);

d.add("ning",-15109);

d.add("niu",-14941);

d.add("nong",-14937);

d.add("nu",-14933);

d.add("nv",-14930);

d.add("nuan",-14929);

d.add("nue",-14928);

d.add("nuo",-14926);

d.add("o",-14922);

d.add("ou",-14921);

d.add("pa",-14914);

d.add("pai",-14908);

d.add("pan",-14902);

d.add("pang",-14894);

d.add("pao",-14889);

d.add("pei",-14882);

d.add("pen",-14873);

d.add("peng",-14871);

d.add("pi",-14857);

d.add("pian",-14678);

d.add("piao",-14674);

d.add("pie",-14670);

d.add("pin",-14668);

d.add("ping",-14663);

d.add("po",-14654);

d.add("pu",-14645);

d.add("qi",-14630);

d.add("qia",-14594);

d.add("qian",-14429);

d.add("qiang",-14407);

d.add("qiao",-14399);

d.add("qie",-14384);

d.add("qin",-14379);

d.add("qing",-14368);

d.add("qiong",-14355);

d.add("qiu",-14353);

d.add("qu",-14345);

d.add("quan",-14170);

d.add("que",-14159);

d.add("qun",-14151);

d.add("ran",-14149);

d.add("rang",-14145);

d.add("rao",-14140);

d.add("re",-14137);

d.add("ren",-14135);

d.add("reng",-14125);

d.add("ri",-14123);

d.add("rong",-14122);

d.add("rou",-14112);

d.add("ru",-14109);

d.add("ruan",-14099);

d.add("rui",-14097);

d.add("run",-14094);

d.add("ruo",-14092);

d.add("sa",-14090);

d.add("sai",-14087);

d.add("san",-14083);

d.add("sang",-13917);

d.add("sao",-13914);

d.add("se",-13910);

d.add("sen",-13907);

d.add("seng",-13906);

d.add("sha",-13905);

d.add("shai",-13896);

d.add("shan",-13894);

d.add("shang",-13878);

d.add("shao",-13870);

d.add("she",-13859);

d.add("shen",-13847);

d.add("sheng",-13831);

d.add("shi",-13658);

d.add("shou",-13611);

d.add("shu",-13601);

d.add("shua",-13406);

d.add("shuai",-13404);

d.add("shuan",-13400);

d.add("shuang",-13398);

d.add("shui",-13395);

d.add("shun",-13391);

d.add("shuo",-13387);

d.add("si",-13383);

d.add("song",-13367);

d.add("sou",-13359);

d.add("su",-13356);

d.add("suan",-13343);

d.add("sui",-13340);

d.add("sun",-13329);

d.add("suo",-13326);

d.add("ta",-13318);

d.add("tai",-13147);

d.add("tan",-13138);

d.add("tang",-13120);

d.add("tao",-13107);

d.add("te",-13096);

d.add("teng",-13095);

d.add("ti",-13091);

d.add("tian",-13076);

d.add("tiao",-13068);

d.add("tie",-13063);

d.add("ting",-13060);

d.add("tong",-12888);

d.add("tou",-12875);

d.add("tu",-12871);

d.add("tuan",-12860);

d.add("tui",-12858);

d.add("tun",-12852);

d.add("tuo",-12849);

d.add("wa",-12838);

d.add("wai",-12831);

d.add("wan",-12829);

d.add("wang",-12812);

d.add("wei",-12802);

d.add("wen",-12607);

d.add("weng",-12597);

d.add("wo",-12594);

d.add("wu",-12585);

d.add("xi",-12556);

d.add("xia",-12359);

d.add("xian",-12346);

d.add("xiang",-12320);

d.add("xiao",-12300);

d.add("xie",-12120);

d.add("xin",-12099);

d.add("xing",-12089);

d.add("xiong",-12074);

d.add("xiu",-12067);

d.add("xu",-12058);

d.add("xuan",-12039);

d.add("xue",-11867);

d.add("xun",-11861);

d.add("ya",-11847);

d.add("yan",-11831);

d.add("yang",-11798);

d.add("yao",-11781);

d.add("ye",-11604);

d.add("yi",-11589);

d.add("yin",-11536);

d.add("ying",-11358);

d.add("yo",-11340);

d.add("yong",-11339);

d.add("you",-11324);

d.add("yu",-11303);

d.add("yuan",-11097);

d.add("yue",-11077);

d.add("yun",-11067);

d.add("za",-11055);

d.add("zai",-11052);

d.add("zan",-11045);

d.add("zang",-11041);

d.add("zao",-11038);

d.add("ze",-11024);

d.add("zei",-11020);

d.add("zen",-11019);

d.add("zeng",-11018);

d.add("zha",-11014);

d.add("zhai",-10838);

d.add("zhan",-10832);

d.add("zhang",-10815);

d.add("zhao",-10800);

d.add("zhe",-10790);

d.add("zhen",-10780);

d.add("zheng",-10764);

d.add("zhi",-10587);

d.add("zhong",-10544);

d.add("zhou",-10533);

d.add("zhu",-10519);

d.add("zhua",-10331);

d.add("zhuai",-10329);

d.add("zhuan",-10328);

d.add("zhuang",-10322);

d.add("zhui",-10315);

d.add("zhun",-10309);

d.add("zhuo",-10307);

d.add("zi",-10296);

d.add("zong",-10281);

d.add("zou",-10274);

d.add("zu",-10270);

d.add("zuan",-10262);

d.add("zui",-10260);

d.add("zun",-10256);

d.add("zuo",-10254);

//////////////////////////////////////

function getKey(code)

{

if ((code>0)&&(code<160))

   return String.fromCharCode(code);

else if ((code<-20319)||(code>-10247))

   return "";

else

for (var i=d.items.length-1;i>=0;i--)

{

   if (d.items[i].value<=code)

   break;

}

return d.items[i].key;

}

function myConvert(str)

{

var result = "" ;

for (var i=1;i<=str.length;i++)

         {

                 execScript("ascCode=asc(mid(\"" + str + "\"," + i + ",1))", "vbscript");

   result = result   + getKey(ascCode);

         }

   document.getElementById("txtNamepy").value = result; 

return result ;

}



//取得纵向滚动条偏移位置
function getPos() {

    var scrollPos;
    if (typeof window.pageYOffset != 'undefined') {
        scrollPos = window.pageYOffset;
    }
    else if (typeof document.compatMode != 'undefined' && document.compatMode != 'BackCompat') {
        scrollPos = document.documentElement.scrollTop;
    }
    else if (typeof document.body != 'undefined') {
        scrollPos = document.body.scrollTop;
    }
    return scrollPos;

}
