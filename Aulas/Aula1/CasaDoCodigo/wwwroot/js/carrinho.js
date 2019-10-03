class Carrinho {

    clickImpremento(btn) {
        let data = this.getData(btn);
        data.quantidade++;
        this.postQuantidade(data);
  
    }

    clickDecremento(btn) {
        let data = this.getData(btn);
        data.quantidade--;
        this.postQuantidade(data);
    }

    getData(elemento) {
        var linhaDoItem = $(elemento).parents('[item-id]')
        var itemId = $(linhaDoItem).attr('item-id');
        var novaQtde = $(linhaDoItem).find('input').val();
        return {
            Id: itemId,
            quantidade: novaQtde
        }
    }

    postQuantidade(data) {
        $.ajax({
            url: '/pedido/updateQuantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        })
            
    }

    updateQuantidade(input) {
        let data = this.getData(input);
        this.postQuantidade(data);


    }

}
var carrinho = new Carrinho();