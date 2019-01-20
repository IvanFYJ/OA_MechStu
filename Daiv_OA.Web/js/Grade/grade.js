
$(function () {
    if (sgjson !== undefined && sgjson !== null && sgjson != '') {
        var sgObject = $.parseJSON(sgjson);
        var selectStr = "";
        var tempshid = 0;
        //console.log(sgObject);
        for (var i = 0; i < sgObject.length; i++) {
            if (shid == sgObject[i].shid) {
                selectStr = "selected";
                tempshid = shid;
            }
            $('#schGid').append('<option value="' + sgObject[i].shid + '" ' + selectStr + ' >' + sgObject[i].shname + '</option>');
            selectStr = "";
        }
        if (tempshid <= 0)
            tempshid = sgObject[0].shid;
        schGradeChange(tempshid);
    }

    $('#schGid').on('change', function () {
        var shid = $(this).val();
        schGradeChange(shid);
    });

    $('#schGradeGid').on('change', function () {
        var shid = $(this).val();
        schClassChange(shid);
    });
});

//年级列表
function schGradeChange(shid) {
    if (sgjson !== undefined && sgjson !== null && sgjson != '') {
        var sgObject = $.parseJSON(sgjson);
        var selectStr = "";
        var tempgid = 0;
        for (var i = 0; i < sgObject.length; i++) {
            if (shid != sgObject[i].shid)
                continue;
            $('#schGradeGid').empty();
            for (var j = 0; j < sgObject[i].grades.length; j++) {
                if (gradeid == sgObject[i].grades[j].ID) {
                    selectStr = "selected";
                    tempgid = gradeid;
                }
                $('#schGradeGid').append('<option value="' + sgObject[i].grades[j].ID + '" ' + selectStr + ' >' + sgObject[i].grades[j].Name + '</option>');
                selectStr = "";
            }
            if (tempgid <= 0)
                tempgid = sgObject[i].grades[0].ID;
            schClassChange(tempgid);
        }
    }
}

//班级列表
function schClassChange(gid) {
    debugger;
    if (gcjson !== undefined && gcjson !== null && gcjson != '') {
        var gcObject = $.parseJSON(gcjson);
        var selectStr = "";
        for (var i = 0; i < gcObject.length; i++) {
            if (gid != gcObject[i].shcgid)
                continue;
            $('#schClassgcid').empty();
            for (var j = 0; j < gcObject[i].classes.length; j++) {
                if (gclassid == gcObject[i].classes[j].Gid) {
                    selectStr = "selected";
                }
                $('#schClassgcid').append('<option value="' + gcObject[i].classes[j].Gid + '" ' + selectStr + ' >' + gcObject[i].classes[j].Gname + '</option>');
                selectStr = "";
            }
        }
    }
}