"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
//plugins
var _ = require("underscore");
var MessageResponse = /** @class */ (function () {
    function MessageResponse(msg) {
        this.error = null;
        this.failedValidation = null;
        this.information = null;
        if (_.isEmpty(msg))
            return;
        this.error = msg.error;
        this.failedValidation = msg.failedValidation;
        this.information = msg.information;
    }
    MessageResponse.prototype.isSuccess = function () {
        return this.error === null && this.failedValidation === null && this.information === null;
    };
    return MessageResponse;
}());
exports.MessageResponse = MessageResponse;
var messageResponse = /** @class */ (function (_super) {
    __extends(messageResponse, _super);
    function messageResponse(msg) {
        var _this = _super.call(this, msg) || this;
        if (_.isEmpty(msg))
            return _this;
        _this.result = msg.result;
        return _this;
    }
    messageResponse.prototype.isSuccess = function () {
        return _super.prototype.isSuccess.call(this);
    };
    return messageResponse;
}(MessageResponse));
exports.messageResponse = messageResponse;
//# sourceMappingURL=messageResponse.js.map