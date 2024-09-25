
namespace AppVendas.Models
{
    internal class MixLengthAttribute : Attribute
    {
        private int v;
        private string errorMessage;

        public MixLengthAttribute(int v, string ErrorMessage)
        {
            this.v = v;
            errorMessage = ErrorMessage;
        }
    }
}