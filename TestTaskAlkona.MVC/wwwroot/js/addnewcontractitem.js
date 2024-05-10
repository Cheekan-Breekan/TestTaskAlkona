$(() => {
    $('#addContractItem').click(function () {
        var itemCount = $('.contractItem').length;
        var newItemHtml = `
                                    <div class="contractItem" id="item${itemCount}">
                                    <label for="itemName">Name:</label>
                                    <input type="text" data-val="true" data-val-required="The Name field is required." id="Items_${itemCount}__Name" name="Items[${itemCount}].Name" value="">
                                    <label for="itemPrice">Price:</label>
                                    <input type="text" data-val="true" data-val-number="The field Price must be a number." data-val-required="The Price field is required." id="Items_${itemCount}__Price" name="Items[${itemCount}].Price" value="0,00">
                                    </div>
                                `;
        $('#contractItems').append(newItemHtml);
    });
})