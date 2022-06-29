using IMS.Core.Utilities.Results;

namespace IMS.Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result._success)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
