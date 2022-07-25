namespace WebApi.Entities
{
    public enum StatusPedido
    {
        PedidoIniciado,
        MontandoReceita,
        PedidoConfirmado,
        AguardandoPagamento,
        Pago,
        EmMontagem,
        NoForno,
        AguardandoRetirada,
        Finalizado
    }
}