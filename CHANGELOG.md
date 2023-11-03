# Changelog  
All notable changes to this project will be documented in this file.  
  
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),  
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).  
  
## [3.1.0] - 2023-11-03  
### Added  
- Added `WebApplication.IsRunningOnWebGL` property and improved `Device.IsMobile` to work in the Editor.  
  
## [3.0.0] - 2023-06-13  
### Removed  
- Removed `WebEventSystem` because Unity OnApplicationFocus() callback bug is now fixed automatically as long as this package is installed.  
  
## [2.2.0] - 2023-04-25  
### Added  
- Added `Device.IsMobile` property that detects if an app is running on any mobile device.  
  
## [2.1.0] - 2023-01-19  
### Added  
- Added `AdBlock.Enabled` property that returns status of an AdBlock addon in the browser.  
  
## [2.0.0] - 2022-08-31  
### Changed  
- Renamed `WebApplication.InBackgroundChange` to `WebApplication.InBackgroundChangeEvent`.  
- Recommended to use both `AudioListener.pause` and `AudioListener.volume` muting methods in `PlaytestingCanvas`.  
  
[3.1.0] https://github.com/forcepusher/com.agava.webutility/compare/3.0.0...3.1.0  
[3.0.0] https://github.com/forcepusher/com.agava.webutility/compare/2.2.0...3.0.0  
[2.2.0] https://github.com/forcepusher/com.agava.webutility/compare/2.1.0...2.2.0  
[2.1.0] https://github.com/forcepusher/com.agava.webutility/compare/2.0.0...2.1.0  
[2.0.0] https://github.com/forcepusher/com.agava.webutility/compare/1.0.0...2.0.0
