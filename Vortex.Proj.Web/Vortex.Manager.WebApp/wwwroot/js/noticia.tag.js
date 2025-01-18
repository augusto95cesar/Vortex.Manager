let tags = [];
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
                callback(data);
            },
            error: function (error) {
                console.error("Erro na requisição AJAX:", error);
            }
        });
    },
    creatTag: (tagName) => {
        var tag = { 
            descricao: tagName
        };

        $.ajax({
            url: '/Tags/Create', // URL da sua Action
            type: 'POST',
            data: tag, // Dados a serem enviados
            dataType: 'json',
            success: function (data) {
                app.getTags(app.atualizarListaTags); 
            },
            error: function (error) {
                console.error("Erro na requisição AJAX:", error);
            }
        });
    },
    creatNoticia: (listTagsId) => {
        var titulo = $("#modalTitulo").val();
        var descricao = $("#modalDescricao").val(); 

        var noticias = {
            titulo: titulo,
            texto: descricao,
            tagsid: listTagsId
        }

        $.ajax({
            url: '/Noticias/Create', // URL da sua Action
            type: 'POST',
            data: noticias, // Dados a serem enviados
            dataType: 'json',
            success: function (data) {
                console.log(data)
                app.fecharModal();
                app.getTags(app.atualizarListaTags); 
            },
            error: function (error) {
                console.error("Erro na requisição AJAX:", error);
            }
        });
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
            app.creatNoticia(tagsSelecionadas);  
        });
        $('#tagModal').on('shown.bs.modal', function () {
            app.getTags(app.atualizarListaTags);
        })
    },     
    atualizarListaTags: (listTags) => {
        $("#tagName").val(""); 
        //tags = listTags.map(objeto => objeto.descricao);
        tags = listTags; 
        console.log(tags)
        $("#tagList").empty();
        if (tags.length === 0) {
            $("#tagList").append("<p>Nenhuma tag cadastrada.</p>");
        } else {
            tags.forEach(function (tag, index) {
                $("#tagList").append(`
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="${tag.codigo}" id="tagCheck${index}">
                                <label class="form-check-label" for="tagCheck${index}">
                                    ${tag.descricao}
                                </label>
                            </div>
                        `);
            });
        }
    },
    fecharModal:() => {
        $("#tagModal").modal('hide'); 
    } 
}

//iniciar javascript
app.init();