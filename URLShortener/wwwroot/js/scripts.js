﻿function confirmDelete() {
    return confirm("Are you sure you want to delete the URL?");
}

async function OnRegenerateBtn() {
    let newShortUrl = await (await fetch('/home/getShortUrl/', {
        method: 'get',
    })).json();
    document.getElementById("shortUrlIn").value = newShortUrl;
}