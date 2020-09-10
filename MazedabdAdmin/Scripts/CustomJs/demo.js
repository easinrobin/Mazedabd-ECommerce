'use strict';

$(document).ready(function () {
    /*--------------------------------------
        Animation
    ---------------------------------------*/
    var animationDuration;


    $('body').on('click', '.animation-demo .card-body .btn', function(){
        var animation = $(this).text();
        var cardImg = $(this).closest('.card').find('img');
        if (animation === "hinge") {
            animationDuration = 2100;
        }
        else {
            animationDuration = 1200;
        }

        cardImg.removeAttr('class');
        cardImg.addClass('animated '+animation);

        setTimeout(function(){
            cardImg.removeClass(animation);
        }, animationDuration);
    });

    $(document).ready(function () {
        $('#summernote').summernote({
            placeholder: 'Write Description',
            tabsize: 2,
            height: 200,
            background: '#fff',
            toolbar: [
                ['style', ['style']],
                ['font', ['bold', 'underline', 'clear', 'italic']],
                ['fontsize', ['fontsize']],
                ['color', ['color']],
                ['para', ['ul', 'ol', 'paragraph']],
                ['table', ['table']],
                ['insert', ['link', 'picture', 'video', 'hr']],
                ['view', ['codeview', 'help', 'undo', 'redo']]
            ]
        });
    });
});