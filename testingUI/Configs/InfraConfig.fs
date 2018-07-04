module configs.InfraConfig

open canopy
open reporters

let InitializeInfrastructureConfig =
    chromeDir <- "C:\drivers"
    ieDir <- "C:\drivers"
    failureScreenshotsEnabled <- true
    failScreenshotPath <- "C:\screenshots"
    elementTimeout <- 20.0
    compareTimeout <- 20.0
    pageTimeout <- 20.0
    failFast := false
    reporter <- new LiveHtmlReporter(Chrome, configuration.chromeDir) :> IReporter
    reporter.setEnvironment "Local Machine"
    let liveHtmlReporter = reporter :?> LiveHtmlReporter
    let nowDate = System.DateTime.UtcNow.ToFileTimeUtc()
    let fullReportPath = System.String.Concat("c:\\reports\\Report-", nowDate)
    liveHtmlReporter.reportPath <- Some fullReportPath
    configuration.failureMessagesThatShoulBeTreatedAsSkip <- ["Skip me when I fail"]