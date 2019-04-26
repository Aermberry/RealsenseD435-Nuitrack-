# RealSense D435接入Nuitrack SDK

由于现行的RealSense SDK2.0 已不再提供Unity的视觉跟踪的smaple,所以改接入第三方的SDK.

#### 安装

RealSense SDk2.0 版本安装（需要根据Nuitrack SDK 匹配的版本调正安装的RealSenseSDK2.0版本）

**RealSense SDK2.0:**  [下载地址](https://github.com/IntelRealSense/librealsense/releases)

**Nuitrack SDK:**  [下载地址](<https://nuitrack.com/>)

#### 检测

RealSense SDK

RealSense SDK安装成功检测，打开**Intel RealSense Viewer**，检测是否能成功进行**RGB成像**和**depth成像**，若都能，则安装成功。另若提示Firmware更新，则需要更新。（参考文档[RealSense固件更新](./doc/RealSense固件更新)）

Nuitrack SDK

打开src:[root]\Nuitrack\nuitrack下的**README.txt文件**，根据提示做**Nuitrack**链接**RealSense Camera Sensor**的检测，若能成像，则链接没有问题

**Unity编译项目检测**

由于在**Unity**中编译时，实际是**Unity**调用**Nuitrack SDK**，**Nuitrack**需要**RealSense SDK2.0**作为依赖，但**Nuitrack**的官方文档没有明确给出具体的**Nuitrack**版本所对应依赖的**RealSense SDK2.0**版本，所以只能根据在**Unity**中**console**的提示进行调正安装，若报错，则会显示出具体需安装的**RealsenseSDK2.0**版本，否则提示运行正常的提示。

> 错误提示如下：
>
> ModuleNotInitializedException: NuitrackException (ModuleNotInitializedException): Can’t create DepthSensor module
> AstraProPerseeDepthProvider: Can’t create RGB Stream (VideoCapture device ID is not valid)
> OpenNI2DepthProvider: Can’t open device (	DeviceOpen using default: no devices found
> )
> OpenNIDepthProvider: Can’t create OpenNI DepthGenerator (OpenNI Status: Can’t create any node of the requested type!)
> API version mismatch: librealsense.so was compiled with API version 2.15.0 but the application was compiled with 2.17.0! Make sure correct version of the library is installed (make install)
>
> nuitrack.NativeImporter.throwException (nuitrack.NativeImporter+ExceptionType type, System.String message) (at :0)
> nuitrack.NativeDepthSensor…ctor () (at :0)
> nuitrack.DepthSensor.Create () (at :0)
> NuitrackManager.NuitrackInit () (at Assets/NuitrackSDK/Nuitrack/Scripts/NuitrackManager.cs:225)
> NuitrackManager.Awake () (at Assets/NuitrackSDK/Nuitrack/Scripts/NuitrackManager.cs:119)

> 无异常的提示：
>
> Init OK
>
> Run OK

**关于实际的人物活动检测**

人的站位需要与**Camera**大约一米的距离
