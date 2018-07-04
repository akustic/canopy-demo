module suites.Runner

open canopy
open configs.InfraConfig

InitializeInfrastructureConfig

ClientSiteSuite.all()

run()

