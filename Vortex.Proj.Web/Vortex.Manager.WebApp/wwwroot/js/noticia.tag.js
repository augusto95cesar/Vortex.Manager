let tags = []; // Array para armazenar as tags (simulação de banco de dados)
let resultTags = []
var app = {
    init: () => {
        this.app.getTags(app.atualizarListaTags)
        this.app.modal();
    },
    getTags: (callback) => {
        $.ajax({
            url: '/Tags/Get',
            type: 'GET',
            dataType: 'json', success: function (data) {
                resultTags = data;
                callback();
            },
            error: function (error) {
                console.error("Erro na requisição AJAX:", error);
            }
        });
    },
    creatTag: (tagName) => {
        var tag = {
            //descricao: $("#Descricao").val() 
            descricao: tagName
        };

        $.ajax({
            url: '/Tags/Create', // URL da sua Action
            type: 'POST',
            data: tag, // Dados a serem enviados
            dataType: 'json',
            success: function (data) {
                app.getTags(app.atualizarListaTags);

                //if (data.sucesso) {

                //} else { 
                //}
            },
            error: function (error) {
                console.error("Erro na requisição AJAX:", error);
            }
        });
    }, creatNoticia: (tagsSelecionadas) => {
        console.log("creatNoticia: ", tagsSelecionadas)

        //var tag = {
        //    //descricao: $("#Descricao").val() 
        //    descricao: tagName
        //};

        //$.ajax({
        //    url: '/Tags/Create', // URL da sua Action
        //    type: 'POST',
        //    data: tag, // Dados a serem enviados
        //    dataType: 'json',
        //    success: function (data) {
        //        app.getTags(app.atualizarListaTags);

        //        //if (data.sucesso) {

        //        //} else { 
        //        //}
        //    },
        //    error: function (error) {
        //        console.error("Erro na requisição AJAX:", error);
        //    }
        //});
    },
    modal: () => {
        $("#addTag").click(function () {
            const tagName = $("#tagName").val().trim();
            if (tagName !== "" && !tags.includes(tagName)) {
                app.creatTag(tagName);
            }
        });
        $("#addTagDisplay").click(function () {
            var display = $("#tagForm").css("display");
            if (display === 'block') {
                $("#tagForm").css("display", "none");
            } else {
                $("#tagForm").css("display", "block");
            }
        });
        $("#saveNoticia").click(function () {
            var tagsSelecionadas = [];
            $("#tagList input:checked").each(function () {
                tagsSelecionadas.push($(this).val());
            });

            $("#tagModal").modal('hide');
            app.creatNoticia(tagsSelecionadas);  
        });
        $('#tagModal').on('shown.bs.modal', function () {
            app.getTags(app.atualizarListaTags);
        })
    },
    atualizarListaTags: () => {
        $("#tagName").val("");
        tags = resultTags.map(objeto => objeto.descricao);
        $("#tagList").empty();
        if (tags.length === 0) {
            $("#tagList").append("<p>Nenhuma tag cadastrada.</p>");
        } else {
            tags.forEach(function (tag, index) {
                $("#tagList").append(`
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="${tag}" id="tagCheck${index}">
                                <label class="form-check-label" for="tagCheck${index}">
                                    ${tag}
                                </label>
                            </div>
                        `);
            });
        }
    }

}

app.init();