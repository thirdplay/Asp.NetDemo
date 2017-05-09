// 名前定義
var PROTOTYPE = PROTOTYPE || {
    common: {}
};

// 共通モジュール
PROTOTYPE.common = (function () {
    'use strict';

    var escapeMap = {
        '&': '&amp;',
        "'": '&#x27;',
        '`': '&#x60;',
        '"': '&quot;',
        '<': '&lt;',
        '>': '&gt;'
    };
    var escapeReg = new RegExp((function () {
        var escapeRegStr = '[';
        for (var p in escapeMap) {
            if (escapeMap.hasOwnProperty(p)) {
                escapeRegStr += p;
            }
        }
        escapeRegStr += ']';
        return escapeRegStr;
    })(), 'g');

    /**
     * 文字列をHTMLエスケープして返却します。
     *
     * @param {string} str エスケープ対象の文字列
     * @returns {string} エスケープ後の文字列
     */
    var escapeHtml = function (str) {
        str = (str === null || str === undefined) ? '' : '' + str;
        return str.replace(escapeReg, function (match) {
            return escapeMap[match];
        });
    };

    /**
     * バリデーションエラーを表示します。
     *
     * @param {array} errors バリデーションエラー情報を格納する配列
     */
    var showValidationErrors = function (errors) {
        var modelStateErrors = errors;
        for (var i = 0; i < modelStateErrors.length; i++) {
            var errorModel = modelStateErrors[i],
                errorMsg = '';

            for (var j = 0; j < errorModel.errors.length; j++) {
                errorMsg += this.escapeHtml(errorModel.errors[j]) + '<br />';
            }
            $("span[data-valmsg-for='" + errorModel.key + "']")
                .html(errorMsg);
        }
    };

    /**
     * バリデーションエラーを非表示にします。
     */
    var hideValidationErrors = function () {
        $('span.field-validation-valid').empty();
    };

    /**
     * メッセージ領域にメッセージを表示します。
     *
     * @param {string} message 表示するメッセージ
     */
    var showMessage = function (message) {
        if ($('#messageArea').length > 0) {
            $('#messageArea').text(message)
                .wrapInner("<strong />")
                .show();
        }
    };

    /**
     * メッセージ領域のメッセージを非表示にします。
     */
    var hideMessage = function () {
        if ($('#messageArea').length > 0) {
            $('#messageArea').empty().hide();
        }
    };

    // Public API
    return {
        escapeHtml: escapeHtml,
        showValidationErrors: showValidationErrors,
        hideValidationErrors: hideValidationErrors,
        showMessage: showMessage,
        hideMessage: hideMessage
    };
}());