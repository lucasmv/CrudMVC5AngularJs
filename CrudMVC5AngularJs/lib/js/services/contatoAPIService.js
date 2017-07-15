angular.module("listaTelefonica").service("contatosAPI", function ($http, config) {
    var _getContatos = function () {
        return $http.get(config.baseUrl + "/contatos");
    };

    var _saveContato = function (contato) {
        return $http.post(config.baseUrl + "/postContato", contato);
    };

    return {
        getContatos: _getContatos,
        saveContato: _saveContato
    };
});