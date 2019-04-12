# RealSense固件更新

工具：

- [intel-realsense-dfu.exe](<https://downloadcenter.intel.com/download/27514/Windows-Device-Firmware-Update-Tool-and-Latest-Firmware-for-Intel-RealSense-D400-Product-Family?v=t>)

- [Firmware bin file](<https://downloadcenter.intel.com/download/28568/Latest-Firmware-for-Intel-RealSense-D400-Product-Family?v=t>)

下載地址：[鏈接](https://downloadcenter.intel.com/download/27514/Windows-Device-Firmware-Update-Tool-and-Latest-Firmware-for-Intel-RealSense-D400-Product-Family?v=t)

**文檔的注意點：**

​	 **DFU Tool 下載鏈接：**

![DFUTool下載鏈接](https://raw.githubusercontent.com/Salmonberry/ImgResource/master/RealSense/DFU%20Tool.png)

​	**.bin file(latest):**

![bin file(latest)](https://raw.githubusercontent.com/Salmonberry/ImgResource/master/RealSense/bin%E6%96%87%E4%BB%B6.png)

**下載下來文件如下：**

![](https://raw.githubusercontent.com/Salmonberry/ImgResource/master/RealSense/file.png)

**解壓後，文件内容如下：**

![](https://raw.githubusercontent.com/Salmonberry/ImgResource/master/RealSense/2019-04-03_14-29-14.png)

**DFU内的主要文件：**
![](https://raw.githubusercontent.com/Salmonberry/ImgResource/master/RealSense/DFU%E4%B8%BB%E8%A6%81%E6%96%87%E4%BB%B6.png)

**.bin的主要文件：**
![](https://raw.githubusercontent.com/Salmonberry/ImgResource/master/RealSense/.binMain%E6%96%87%E4%BB%B6.png)
**操作步驟：**
![](https://raw.githubusercontent.com/Salmonberry/ImgResource/master/RealSense/steps.png)

>DFU工具步驟
        1.在帶有USB 3.1端口的PC上安裝Windows 10。
        2.複製粘貼DFU工具和相應的D400系列
            固件.bin文件到Windows 10主機。注意哪個目錄
            文件存儲在。
        3.打開DFU工具目錄，右鍵單擊intel-realsense-dfu.exe，
            並選擇以管理員身份運行。
             >您也可以以管理員身份打開命令行並運行
            intel-realsense-dfu.exe來自那裡。
        4.將D400系列相機插入Windows 10主機系統
            通過USB 3線連接到USB 3端口。命令行窗口
            應顯示正在顯示的工具的主菜單。
            >按2然後按[ENTER]顯示可更新攝像機列表。
        5.在命令行窗口中生成一個列表;按1
           [ENTER]選擇D400系列相機並開始固件
           更新過程。
        6.提示要求用戶輸入固件.bin文件的文件路徑。
           >鍵入包含固件文件名的完整文件路徑
           按[ENTER]。
        7.下載字節發送的通知輸出。這個流程
            大約需要3分鐘才能完成。
        8.固件升級完成後，攝像機將重置。一個
            Windows圖標說設備正在進行其他設置
            應該彈出。主菜單重新出現。
        9.按4驗證相機上安裝的固件版本
           並按[ENTER]後跟1和[ENTER] ..
注意：已連接的英特爾®實感™攝像頭的固件版本已更改。

具體主要的步驟説明：

- **以管理員權限打開dfu.exe文件**

  ![](https://raw.githubusercontent.com/Salmonberry/ImgResource/master/RealSense/mastertoOpendue.png)

- 選取選項 **1** 進行更新固件
  - 根據計算機上裝載的camera數量輸入相應的camera數量
  - 獲取.bin文件的所在路徑，複製粘貼到此處，**[Enter]**后程序自動加載更新

![](https://raw.githubusercontent.com/Salmonberry/ImgResource/master/RealSense/console.png)

