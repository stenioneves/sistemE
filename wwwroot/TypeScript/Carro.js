var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Carro = /** @class */ (function () {
    function Carro(nomeCarro) {
        this.nome = nomeCarro;
    }
    Carro.prototype.CriarNomeCarro = function () {
        return "Seu carro e : " + this.nome;
    };
    return Carro;
}());
var Trator = /** @class */ (function (_super) {
    __extends(Trator, _super);
    function Trator() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return Trator;
}(Carro));
//# sourceMappingURL=Carro.js.map