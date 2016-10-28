(function () {
    $(function () {
        var _service = abp.services.app.applicationLanguageText;
        var _$modal = $('#ApplicationLanguageTextDeleteModal');
        var _$form = _$modal.find('form');

        var _$table = $('#ApplicationLanguageTexts');
        _$table.find('button[name="delete"]').click(function (e) {
            _$modal.modal('show');
            var id = this.value;
            _$form.find('input[name="Id"]').val(id);
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            var id = _$form.find('input[name="Id"]').val();

            abp.ui.setBusy(_$modal);
            _service.delete({ Id: id }).done(function () {
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