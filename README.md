# SplitQueryPoolExhaustionRepro

`UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)` causes connection pool exhaustion. 

## Steps to reproduce

1. `dotnet ef database update`
2. Install [k6 performance testing tool](https://k6.io/docs/getting-started/installation/)
3. Run the project
4. `k6 run load_test_k6.js`
5. Check output for `System.InvalidOperationException: Timeout expired.  The timeout period elapsed prior to obtaining a connection from the pool.  This may have occurred because all pooled connections were in use and max pool size was reached.`
