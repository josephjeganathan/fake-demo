# Fake Targets

## List targets

```
Fake.exe build.fsx -lt
```
## Single target

```
Fake.exe build.fsx "Deploy" -st
```

## Prallel Jobs

```
tools\FAKE\tools\Fake.exe 03.DependenciesAndPrallelJobs.fsx "parallel-jobs=8"
```

## References

- API Reference: [https://fake.build/apidocs/index.html](https://fake.build/apidocs/index.html)
- Targets and Dependencies: [https://fake.build/core-targets.html](https://fake.build/core-targets.html)
- Legacy Index: [https://fake.build/legacy-index.html](https://fake.build/legacy-index.html)
