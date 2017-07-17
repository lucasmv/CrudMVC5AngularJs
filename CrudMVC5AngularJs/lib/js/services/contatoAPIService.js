angular.module("listaTelefonica").service("contatosAPI", function ($http, config) {
    var _getContatos = function () {
        return $http.get(config.baseUrl + "/contatos");
    };

    var _saveContato = function (contato) {
        return $http.post(config.baseUrl + "/postContato", contato);
    };

    var _apagarContatos = function (contatos) {
        return $http.post(config.baseUrl + "/deleteContato/", contatos);
    };

    return {
        getContatos: _getContatos,
        saveContato: _saveContato,
        apagarContatos: _apagarContatos
    };
});