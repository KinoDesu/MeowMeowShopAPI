let checkbox = document.querySelector("input")
checkbox.addEventListener("change", function () {
    clearProducts()
    getUri()
})
getUri()
async function getUri() {
    const rep = await fetch("../assets/infos.json")

    var data = await rep.json()

    if (checkbox.checked) {
        showOffProducts(data["uri"])
    } else {
        showProduct(data["uri"])
    }
}
async function showProduct(uri) {

    const a = await fetch(uri).then((response) => response.json())
    var section = document.getElementById("products")

    for (var i = 0; i < a.length; i++) {

        if (a[i].imagens[0].link.search("./assets/img/") == -1) {
            a[i].imagens[0].link = "./assets/img/no image.png"
        }

        if (a[i].desconto == 0) {
            var obj = {
                "id": a[i].id,
                "nome": a[i].nome,
                "descricao": a[i].descricao,
                "preco": a[i].preco,
                "imagem": a[i].imagens[0].link
            }
            var div = document.createElement("card")
            div.setAttribute("class", "card")
            section.appendChild(div)

            var nomeProduto = document.createElement("h2")
            var imagemProduto = document.createElement("img")
            var precoProduto = document.createElement("span")

            nomeProduto.setAttribute("class", "nome_produto")
            imagemProduto.setAttribute("class", "img_produto")
            precoProduto.setAttribute("class", "preco_produto")

            nomeProduto.textContent = `${obj.nome}`
            imagemProduto.src = obj.imagem
            precoProduto.textContent = `R$ ${parseFloat(obj.preco).toFixed(2).replace(".", ",")}`

            div.appendChild(nomeProduto)
            div.appendChild(imagemProduto)
            div.appendChild(precoProduto)
        } else {
            var precoNovo = parseFloat(a[i].preco) - parseFloat(a[i].preco) * (parseFloat(a[i].desconto) / 100)
            var obj = {
                "id": a[i].id,
                "nome": a[i].nome,
                "descricao": a[i].descricao,
                "precoNovo": precoNovo,
                "precoVelho": a[i].preco,
                "imagem": a[i].imagens[0].link
            }
            var div = document.createElement("card")
            div.setAttribute("class", "card")
            section.appendChild(div)

            var nomeProduto = document.createElement("h2")
            var imagemProduto = document.createElement("img")
            var precoProduto = document.createElement("span")
            var desconto = document.createElement("div")
            var precoVelho = document.createElement("span")

            desconto.setAttribute("class", "box_desconto")
            nomeProduto.setAttribute("class", "nome_produto")
            imagemProduto.setAttribute("class", "img_produto")
            precoProduto.setAttribute("class", "preco_produto")
            precoVelho.setAttribute("class", "preco_velho")

            nomeProduto.textContent = `${obj.nome}`
            imagemProduto.src = obj.imagem
            precoProduto.innerHTML = `R$ ${parseFloat(obj.precoNovo).toFixed(2).replace(".", ",")}`
            precoVelho.innerHTML = `R$ ${parseFloat(obj.precoVelho).toFixed(2).replace(".", ",")}`
            desconto.innerHTML = `<span class="desconto">-${parseFloat(a[i].desconto).toString().replace(".", ",")}%</span>`

            div.appendChild(nomeProduto)
            div.appendChild(desconto)
            div.appendChild(imagemProduto)
            div.appendChild(precoProduto)
            div.appendChild(precoVelho)
        }
    }
}

async function showOffProducts(uri) {

    const a = await fetch(uri).then((response) => response.json())
    var section = document.getElementById("products")

    for (var i = 0; i < a.length; i++) {

        if (a[i].imagens[0].link.search("./assets/img/") == -1) {
            a[i].imagens[0].link = "./assets/img/no image.png"
        }

        if (a[i].desconto != 0) {
            var precoNovo = parseFloat(a[i].preco) - parseFloat(a[i].preco) * (parseFloat(a[i].desconto) / 100)
            var obj = {
                "id": a[i].id,
                "nome": a[i].nome,
                "descricao": a[i].descricao,
                "precoNovo": precoNovo,
                "precoVelho": a[i].preco,
                "imagem": a[i].imagens[0].link
            }
            var div = document.createElement("card")
            div.setAttribute("class", "card")
            section.appendChild(div)

            var nomeProduto = document.createElement("h2")
            var imagemProduto = document.createElement("img")
            var precoProduto = document.createElement("span")
            var desconto = document.createElement("div")
            var precoVelho = document.createElement("span")

            desconto.setAttribute("class", "box_desconto")
            nomeProduto.setAttribute("class", "nome_produto")
            imagemProduto.setAttribute("class", "img_produto")
            precoProduto.setAttribute("class", "preco_produto")
            precoVelho.setAttribute("class", "preco_velho")

            nomeProduto.textContent = `${obj.nome}`
            imagemProduto.src = obj.imagem
            precoProduto.innerHTML = `R$ ${parseFloat(obj.precoNovo).toFixed(2).replace(".", ",")}`
            precoVelho.innerHTML = `R$ ${parseFloat(obj.precoVelho).toFixed(2).replace(".", ",")}`
            desconto.innerHTML = `<span class="desconto">-${parseFloat(a[i].desconto).toString().replace(".", ",")}%</span>`

            div.appendChild(nomeProduto)
            div.appendChild(desconto)
            div.appendChild(imagemProduto)
            div.appendChild(precoProduto)
            div.appendChild(precoVelho)
        }
    }
}

function clearProducts() {

    var exit = 0;
    while (exit == 0) {
        try {
            var card = document.querySelector(".card")
            let link = card.nextElementSibling
            card.remove()
            if (card.getAttribute("class") == "card") {
                link.remove()
            }
        } catch (e) {
            exit = 1
        }
    }
}