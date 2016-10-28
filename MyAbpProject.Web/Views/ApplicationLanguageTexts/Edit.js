(function () {
    $(function () {
        var _service = abp.services.app.applicationLanguageText;
        var _$modal = $('#ApplicationLanguageTextEditModal');
        var _$form = _$modal.find('form');

        var _$table = $('#ApplicationLanguageTexts');
        _$table.find('button[name="edit"]').click(function (e) {
            var id = this.value;
            _service.get({ Id: id }).done(function (data) {
                _$modal.modal('show');
                _$form.find('input[name="Id"]').val(data.id);
                _$form.find('input[name="LanguageName"]').val(data.languageName);
                _$form.find('input[name="Source"]').val(data.source);
                _$form.find('input[name="Key"]').val(data.key);
                _$form.find('input[name="Value"]').val(data.value);
            });
        });


        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            var applicationLanguageText = _$form.serializeFormToObject(); 

            abp.ui.setBusy(_$modal);
            _service.update(applicationLanguageText).done(function () {
                _$modal.modal('hide');
                location.reload(true); 
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });
    })
})();