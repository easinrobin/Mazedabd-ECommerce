var homeLocation = window.location.protocol + "//" + window.location.host + "/";
var url = window.location.href;

function submitFormReq() {
    if (url.indexOf("/Home/About") > -1) {
        $('#aboutUsForm').submit();
    }
    else if (url.indexOf("/Company/CompanySettings") > -1) {
        $('#companySettingForm').submit();
    }
    else if (url.indexOf("/News/InsertNews") > -1) {
        $('#newsForm').submit();
    }
}

$(document).on('click', '#formCancelBtn', function (e) {
    e.preventDefault();
    Swal.fire({
        title: "Cancel",
        text: "You will loose any unsaved changes. Do you want to proceed?",
        icon: 'warning',
        allowOutsideClick: false,
        showCancelButton: true,
        background: '#0A0C18',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: "Cancel",
        confirmButtonText: "Yes"
    }).then((result) => {
        if (result.value) {
            window.location.href = homeLocation;
        }
    });
});

$(document).on('click', '#formSubmitBtn', function (e) {
    e.preventDefault();
    Swal.fire({
        title: "Submit Form",
        text: "You are about to update the document. Do you want to proceed?",
        icon: 'warning',
        allowOutsideClick: false,
        showCancelButton: true,
        background: '#0A0C18',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: "Cancel",
        confirmButtonText: "Yes"
    }).then((result) => {
        if (result.value) {
            submitFormReq();
        }
    });
});