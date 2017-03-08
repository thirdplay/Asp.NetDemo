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
     * @param {String} str エスケープ対象の文字列
     * @returns {String} エスケープ後の文字列
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
     * @param {Object} errors モデルバインディング状態エラー
     */
    var displayValidationErrors = function (errors) {
        var modelStateErrors = errors;
        for (var i = 0; i < modelStateErrors.length; i++) {
            var errorModel = modelStateErrors[i],
                errorMsg = '';

            for (var j = 0; j < errorModel.errors.length; j++) {
                errorMsg += this.escapeHtml(errorModel.errors[j]) + '<br />';
            }
            $('span[data-valmsg-for="' + errorModel.key + '"]').html(errorMsg);
        }
    };

    return {
        escapeHtml: escapeHtml,
        displayValidationErrors: displayValidationErrors
    };
}());