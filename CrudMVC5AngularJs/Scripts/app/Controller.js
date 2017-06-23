app.controller("crudCtrl", function ($scope, crudService) {

    $scope.divCelular = false;

    obterCelulares();

    function obterCelulares() {
        //debugger;

        var celularesData = crudService.ObterCelulares();
        celularesData.then(
            function (celular) {
                $scope.celulares = celular.data;
            },
            function () {
                toastr["error"]("Erro ao obter os celulares", "CRUD MVC e AngularJS");
            }
        )
    }

    $scope.excluirCelular = function (celular) {

        var celulardata = crudService.ExcluirCelular(celular.Id);

        celulardata.then(function (data) {
            if (data.status == 200) {
                toastr["success"]("Celular excluído com sucesso!", "CRUD MVC e AngularJS");
            }

            obterCelulares();

        }, function () {
            toastr["error"]("Erro ao excluir", "CRUD MVC e AngularJS");
        });
    }

    $scope.obterPorId = function (celular) {

        var celularData = crudService.ObterCelularPorId(celular.Id);

        celularData.then(function (_celular) {
            $scope.celular = _celular.data;
            $scope.celularId = celular.Id;
            $scope.Marca = celular.Marca;
            $scope.Modelo = celular.Modelo;
            $scope.Cor = celular.Cor;
            $scope.TipoChip = celular.TipoChip;
            $scope.MemoriaInterna = celular.MemoriaInterna;
            $scope.Action = "Atualizar";
            $scope.divCelular = true;
        }, function () {
            toastr["error"]("Erro ao obter celular por id!", "CRUD com MVC e AngularJS");
        });
    }

    $scope.AdicionarAtualizarCelular = function () {

        var celular = {
            Marca: $scope.Marca,
            Modelo: $scope.Modelo,
            Cor: $scope.Cor,
            TipoChip: $scope.TipoChip,
            MemoriaInterna: $scope.MemoriaInterna
        };

        var valorAcao = $scope.Action;

        if (valorAcao == "Atualizar") {

            celular.Id = $scope.celularId;

            var celularData = crudService.AtualizarCelular(celular);

            celularData.then(function (data) {

                obterCelulares();

                $scope.divCelular = false;

                if (data.status == 200) {
                    toastr["success"]("Celular alterado com sucesso!", "CRUD com MVC e AngularJS");
                }

            }, function () {
                toastr["error"]("Erro ao atualizar!", "CRUD com MVC e AngularJS");
            });
        } else {

            var celularData = crudService.AdicionarCelular(celular);

            celularData.then(function (data) {

                obterCelulares();

                if (data.status == 200) {
                    toastr["success"]("Celular cadastrado com sucesso!", "CRUD com MVC e AngularJS");
                }

                $scope.divCelular = false;

            }, function () {
                toastr["error"]("Erro ao incluir!", "CRUD com MVC e AngularJS");
            });
        }
    }

    $scope.incluirCelularDiv = function () {

        limparCampos();

        $scope.Action = "Adicionar";
        $scope.divCelular = true;
    }

    $scope.Cancelar = function () {
        $scope.divCelular = false;
    };

    function limparCampos() {

        $scope.celularId = "";
        $scope.Marca = "";
        $scope.Modelo = "";
        $scope.Cor = "";
        $scope.TipoChip = "";
        $scope.MemoriaInterna = "";
    }

});