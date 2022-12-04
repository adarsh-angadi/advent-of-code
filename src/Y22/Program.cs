using Y22;

AppDomain.CurrentDomain
    .GetAssemblies()
    .SelectMany(assembly => assembly.GetTypes())
    .Where(type => typeof(IPuzzleSolver).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
    .Select(puzzleSolverType => Activator.CreateInstance(puzzleSolverType) as IPuzzleSolver)
    .ToList()
    .ForEach(puzzleSolverInstance => puzzleSolverInstance.PrintResults());