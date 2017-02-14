namespace MixERP.Net.VCards.Types
{
    /// <summary>
    /// Specifies the formatted text corresponding to delivery address of the object the vCard represents.
    /// </summary>
    public sealed class DeliveryAddress
    {
        public AddressType Type { get; set; }
        public string Address { get; set; }
    }
}