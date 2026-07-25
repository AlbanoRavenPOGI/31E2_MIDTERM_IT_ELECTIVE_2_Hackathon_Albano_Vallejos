function updatePreview() {

    let type = document.getElementById("eventType").value;

    let preview = document.getElementById("preview");

    if (type == "Wedding") {

        preview.innerHTML = `
<h2>💍 Wedding</h2>

<p>

Together with their families,

invite you to celebrate their wedding.

</p>

`;

    }

    else if (type == "Birthday") {

        preview.innerHTML = `
<h2>🎂 Birthday Party</h2>

<p>

Join us for an unforgettable birthday celebration!

</p>

`;

    }

    else {

        preview.innerHTML = `
<h2>👶 Christening</h2>

<p>

Please join us in celebrating this special day.

</p>

`;

    }

}

updatePreview();