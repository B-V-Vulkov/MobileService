namespace MobileService.CodeGenerator
{
    using System;

    public static class OrderCodeGenerator
    {
        public static string GenerateOrderCode()
        {
            var code = Guid.NewGuid().ToString()
                .Split('-')[0]
                .ToUpper();

            return code;
        }
    }
}
