<h1 align="center" style="border-bottom: none">
    <b>
        <a href="https://doc.rentsoft.cn/">open-im-sdk-dotnet</a><br>
    </b>
</h1>

## 安装

1. 下载代码

```shell
git clone https://github.com/openimsdk/open-im-sdk-dotnet
```

2. 打包 nupkg

```shell
dotnet pack open-im-sdk.csproj -c Release #会在/bin目录下生成open-im-sdk.1.0.0.nupkg
```
3. 安装

##### 复制open-im-sdk.1.0.0.nupkgg到自己的工程目录下并安装包

```shell
dotnet add package --source ./ open-im-sdk -v 1.0.0
```