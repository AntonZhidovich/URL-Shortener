function confirmDelete() {
    return confirm("Are you sure you want to delete the URL?");
}

async function OnRegenerateBtn() {
    let newShortUrl = await (await fetch('/home/getShortUrl/', {
        method: 'get',
    })).json();
    document.getElementById("shortUrlIn").value = newShortUrl;
}

function UrlIsValid() {

    let urlIn = document.getElementById("fullUrlIn");
    let fullUrl = urlIn.value;
    try {
        new URL(fullUrl);
    }
    catch (e) {
        urlIn.style.borderColor = "red";
        document.getElementById("urlErrorAlert").style.display = "block";
        return false;
    }

    return true;
}