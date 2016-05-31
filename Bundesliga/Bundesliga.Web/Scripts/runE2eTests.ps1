Start-Job -ScriptBlock {node webdriver-manager start --standalone}
$invocation = (Get-Variable MyInvocation).Value
$directorypath = Split-Path $invocation.MyCommand.Path
$configpath = $directorypath + '\protractor.conf.js'
protractor $configpath