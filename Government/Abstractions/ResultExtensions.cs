namespace Government.Abstractions
{
    public static class ResultExtensions
    {
        public static ObjectResult ToProblem(this Result result, int statuscode)
        {

            if (result.IsSuccess)
                throw new InvalidOperationException("cant convert succes operation to a problem");

            var problem = Results.Problem(statusCode: statuscode);
            var problemdetails = problem.GetType().GetProperty(nameof(ProblemDetails))!.GetValue(problem) as ProblemDetails;
            problemdetails!.Extensions = new Dictionary<string, object?>
                {
                    {
                        "error",new[]{result.Error}

                    }

                };
            return new ObjectResult(problemdetails);
        }
    }
}