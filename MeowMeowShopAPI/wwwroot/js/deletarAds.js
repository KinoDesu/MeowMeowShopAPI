    let deletar = setInterval(() => { deletarAds() }, 200)
async function deletarAds() {
    try {
        var exit = 0;
            while (exit == 0) {
                let link = document.querySelector("footer").nextElementSibling
                if (link.tagName != "HTML") {
                    link.remove()
                }
                else {
                    exit = 1
                }
            }

    } catch (e) {

        
    }

};

        setTimeout(() => { clearInterval(deletar); }, 5000);             