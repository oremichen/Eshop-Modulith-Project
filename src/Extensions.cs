using System;

public static class Extensions
{
	public static IApplicationBuilder UseMigration<TContext>(this IApplicationBuilder app)
	{
		InitialiseDatabaseAsync(app).GetAwaiter().GetResult();
		return app;
	}
}