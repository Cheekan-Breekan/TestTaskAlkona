$(() => {
    $('#addContractItem').click(function () {
        var itemCount = $('.contractItem').length;
        if (itemCount >= 50) {
            $('#addContractItem').hide();
            return;
        }
        var newItemHtml = `
                                    <div class="contractItem">
                <div>
                    <label class="fs-5 m-0" for="itemName">Наименование</label>
                    <div>
                        <input type="text" class="box" id="Items_${itemCount}__Name" name="Items[${itemCount}].Name" />
                    </div>
                </div>
                <div>
                    <label class="fs-5 m-0" for="itemPrice">Цена</label>
                    <div>
                        <input class="box" type="number" id="Items_${itemCount}__Price" name="Items[${itemCount}].Price" value="0" />
                    </div>
                </div>
            </div>
                                `;
        $('#contractItems').append(newItemHtml);
    });
})

