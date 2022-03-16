Param(
    [Parameter(Mandatory=$true)][string] $PackagePath
)

#require Appx

Write-Information "Install Package"

Add-AppxPackage -Path $PackagePath

Write-Information "Finished Package"