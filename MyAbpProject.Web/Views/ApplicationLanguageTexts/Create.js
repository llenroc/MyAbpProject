(function () {
    $(function () {
        var _service = abp.services.app.applicationLanguageText;
        var _$modal = $('#ApplicationLanguageTextCreateModal');
        var _$form = _$modal.find('form');

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            var applicationLanguageText = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _service.create(applicationLanguageText).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });
    })
})();