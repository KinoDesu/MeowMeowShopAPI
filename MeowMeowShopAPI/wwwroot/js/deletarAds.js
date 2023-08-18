function deletarAds() {

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
};

setTimeout(() => { deletarAds() }, 300)