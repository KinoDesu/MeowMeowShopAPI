async function showProduct() {
    const uri = 'Produto/'

    async function getProductFromAPI(uri, id) {
        const produto = await fetch(uri + id).then(response => response.json())

        console.log(produto)
    }

    getProductFromAPI(uri, 2);

    const a = await fetch('Produto').then((response) => response.json())
    var section = document.getElementById("products")

    for (var i = 0; i < a.length; i++) {

        var obj = {
            "id": a[i].id,
            "nome": a[i].nome,
            "descricao": a[i].descricao,
            "preco": a[i].preco,
            "imagem": a[i].imagens[0].url
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
        precoProduto.textContent = `R$ ${obj.preco}`

        div.appendChild(nomeProduto)
        div.appendChild(imagemProduto)
        div.appendChild(precoProduto)
    }
}

showProduct()