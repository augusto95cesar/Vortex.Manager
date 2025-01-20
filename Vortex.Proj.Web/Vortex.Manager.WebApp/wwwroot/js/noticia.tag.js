let tags = [];
let editNotica = 0;
var app = {
    init: () => {
        this.app.getNoticias(app.atualizarListaNoticias);
        this.app.getTags(app.atualizarListaTags);
        this.app.modal();
    },
    getNoticias: (callback) => {
        var rota = '/Noticias'
        if (editNotica === 0 || editNotica === null) {
            rota += '/Get';
        } else {
            rota += '/GetNoticia/' + editNotica;
        }

        $.ajax({
            url: rota,
            type: 'GET',
            dataType: 'json', success: function (data) {
                callback(data);
            },
            error: function (error) {
                notification.addNotification(error, 'error')
                //console.log("Erro getNoticias:", error);
            }
        });
    },
    montarTagHtml: (noticia) => {
        var tagsHtml = '';
        noticia.tags.forEach((tag) => {
            tagsHtml += `<a style="background:#1a5e8f; color:white;" 
                                class="badge me-2 mb-2 
                                text-decoration-none"  id="tag-noticia_${tag.codigo}"  tag-notica>
                                    ${tag.descricao}
                               </a> `;
        });

        return tagsHtml;
    },
    montarNoticiaHtml: (noticia) => {
        try { $("#noticiaIgualAZero").remove(); } catch { }

        var tagsHtml = app.montarTagHtml(noticia);
        var html = `<div class="card">
                            <div class="card-header">
                               <div class="row">
                                   <div class="col-10">
                                        <h5 class="card-title" titulo-notica>${noticia.titulo}</h5>
                                   </div>
                                    <div class="col-2 engrenagem">
                                        <div class="row">
                                            <div class="col-6"><img onclick="app.configurationNoticia(${noticia.codigo})" src="img/engrenagem.png" /></div>
                                            <div class="col-6"><img onclick="app.excluirNoticia(${noticia.codigo})" src="img/excluir.png" /></div>
                                        </div>
                                    </div>
                               </div>
                            </div>
                            <div class="card-body">
                                <p class="card-text" text-notica>
                                    ${noticia.descricao}
                                </p>
                                <div class="mt-3">
                                    <h6>Tags:</h6>
                                    <div class="d-flex flex-wrap" >
                                        ${tagsHtml}
                                    </div>
                                </div>
                            </div>
                        </div> `


        return html;
    },
    addNoticiaHtml: (noticia) => {
        var montarNoticiaHtml = app.montarNoticiaHtml(noticia);
        var html = `<div class="container mt-5" id="noticiaId_${noticia.codigo}">
                        ${montarNoticiaHtml}
                    </div>`
        return html;
    },
    updateNoticiaHtml: (noticias) => {
        var noticia = noticias[0]
        var noticiaHtml = app.montarNoticiaHtml(noticia);
        $(`#noticiaId_${noticia.codigo}`).html(noticiaHtml)
    },
    atualizarListaNoticias: (noticias) => {        
        if (noticias.length === 0) { 
            $("#body-noticias").prepend("<p id='noticiaIgualAZero'>Nenhuma notícia cadastrada.</p>")
        } else {
            noticias.forEach(function (noticia) {
                $("#body-noticias").prepend(app.addNoticiaHtml(noticia));
            });
        }
    },
    getTags: (callback) => {
        $.ajax({
            url: '/Tags/Get',
            type: 'GET',
            dataType: 'json', success: function (data) {
                callback(data);
            },
            error: function (error) {
                notification.addNotification(error, 'error')
                //console.log("Erro getTags:", error);
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
                $("#tagForm").css("display", "none");
                $("#tagFormBody").css("display", "block");
                app.getTags(app.atualizarListaTags);
                notification.addNotification('Taga Criada com Sucesso!', 'ok')
            },
            error: function (error) {
                notification.addNotification('Erro ao Cadatrar Tagas', 'error')
                //console.log("Erro na requisição AJAX:", error);
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
                //console.log("teste de info",data)
                app.atualizarListaNoticias(data);
                app.fecharModal();
                notification.addNotification('Noticía Criada com Sucesso!', 'ok')
            },
            error: function (error) {
                console.log("Erro creatNoticia:", error);
                notification.addNotification('Erro ao Cadastrar Noticia', 'error')
            }
        });
    },
    editNoticia: (listTagsId) => {
        var titulo = $("#modalTitulo").val();
        var descricao = $("#modalDescricao").val();

        var noticias = {
            id: editNotica,
            titulo: titulo,
            texto: descricao,
            tagsid: listTagsId
        }

        $.ajax({
            url: '/Noticias/Edit', // URL da sua Action
            type: 'PUT',
            data: noticias, // Dados a serem enviados
            dataType: 'json',
            success: function (data) {
                app.updateNoticiaHtml(data);
                app.fecharModal();
                notification.addNotification('Notícia modificada com Sucesso!', 'ok')
            },
            error: function (error) {
                //console.log("Erro creatNoticia:", error);
                notification.addNotification(error, 'error')
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
                $("#tagFormBody").css("display", "block");
            } else {
                $("#tagForm").css("display", "block");
                $("#tagFormBody").css("display", "none");
            }
        });
        $("#saveNoticia").click(function () {
            var tagsSelecionadas = [];
            $("#tagList input:checked").each(function () {
                tagsSelecionadas.push($(this).val());
            });

            if (editNotica === 0) {
                app.creatNoticia(tagsSelecionadas);
            }
            else {
                app.editNoticia(tagsSelecionadas);
            }
        });
    },
    atualizarListaTags: (listTags) => {
        $("#tagName").val("");
        tags = listTags;
        $("#tagList").empty();
        if (tags.length === 0) {
            $("#tagList").append("<p>Nenhuma tag cadastrada.</p>");
        } else {
            tags.forEach(function (tag) {
                $("#tagList").append(`
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="${tag.codigo}" id="tagCheck${tag.codigo}">
                                <label class="form-check-label" for="tagCheck${tag.codigo}">
                                    ${tag.descricao}
                                </label>
                            </div>
                        `);
            });
        }
    },
    fecharModal: () => {
        $("#tagModal").modal('hide');
    },
    configurationNoticia: (idNoticia) => {
        editNotica = idNoticia;
        //app.getTags();
        app.getNoticias((e) => {
            //console.log(e)
            this.app.getTags((c) => {
                app.atualizarListaTags(c);
                e[0].tags.forEach(function (tag) {
                    $('#tagCheck' + tag.codigo).prop("checked", true);
                });
            });

            $("#modalTitulo").val(e[0].titulo);
            $("#modalDescricao").val(e[0].descricao);
            $("#tagModal").modal('show');
        });
    },
    addNoticia: () => {
        this.app.getTags(app.atualizarListaTags);
        editNotica = 0;
        $("#modalTitulo").val('');
        $("#modalDescricao").val('');
        $("#tagModal").modal('show');
    },
    excluirNoticia: (idNoticia) => {
        var rota = '/Noticias/Delete/' + idNoticia
        $.ajax({
            url: rota,
            type: 'DELETE',
            dataType: 'json', success: function (data) {
                $('#noticiaId_' + idNoticia).remove();
                $("#body-noticias").html('')
                app.getNoticias(app.atualizarListaNoticias);
                notification.addNotification('Notícia Excluida com Sucesso!', 'ok')
            },
            error: function (error) {
                //console.log("Erro getNoticias:", error);
                notification.addNotification(error, 'error')
            }
        });
    }
}

//iniciar javascript
app.init();