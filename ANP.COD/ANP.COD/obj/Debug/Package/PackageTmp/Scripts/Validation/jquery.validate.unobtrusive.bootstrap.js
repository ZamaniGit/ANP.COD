(function ($) {
    var classes = { groupIdentifier: '.form-group', error: 'has-error', success: 'has-success', feedback: 'has-feedback' };
    function updateClasses(inputElement, toAdd, toRemove, addFeedback) {
        var group = inputElement.closest(classes.groupIdentifier);
        if (group.length > 0) {
            group.addClass(toAdd).removeClass(toRemove);
            if (addFeedback) {
                group.addClass(classes.feedback);
            }
        }
    }

    function onError(inputElement, message) {
        var group = inputElement.closest(classes.groupIdentifier);
        var inputGroup = inputElement.closest('.input-group');
        var helpBlock = '<span class="help-block">' + message + '</span>';

        group.find('.form-control-feedback').remove();
        if (group.find('.help-block').length > 0) {
            group.find('.help-block').text(message);
        } else {
            if (inputGroup.length > 0) {
                inputGroup.after(helpBlock);
            } else {
                inputElement.after(helpBlock);
            }
        }

        if (inputElement.context.type === 'text') {
            var errorIcon = '<span class="glyphicon glyphicon-remove form-control-feedback" aria-hidden="true"></span>';
            if (inputGroup.length > 0) {
                inputGroup.after(errorIcon);
            } else {
                inputElement.after(errorIcon);
            }
            updateClasses(inputElement, classes.error, classes.success, true);
        } else {
            updateClasses(inputElement, classes.error, classes.success, false);
        }
    }

    function onSuccess(inputElement) {
        var group = inputElement.closest(classes.groupIdentifier);
        var inputGroup = inputElement.closest('.input-group');

        group.find('.form-control-feedback').remove();
        group.find('.help-block').remove();
        if (inputElement.context.type === 'text') {
            var successIcon = '<span class="glyphicon glyphicon-ok form-control-feedback" aria-hidden="true"></span>';
            if (inputGroup.length > 0) {
                inputGroup.after(successIcon);
            } else {
                inputElement.after(successIcon);
            }
            updateClasses(inputElement, classes.success, classes.error, true);
        } else {
            updateClasses(inputElement, classes.success, classes.error, false);
        }
    }

    function onValidated(errorMap, errorList) {
        $.each(errorList, function () {
            onError($(this.element), this.message);
        });

        if (this.settings.success) {
            $.each(this.successList, function () {
                onSuccess($(this));
            });
        }
    }

    $(function () {
        $('form').each(function () {
            var validator = $(this).data('validator');
            validator.settings.showErrors = onValidated;
        });
    });
}(jQuery));
