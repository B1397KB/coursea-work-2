# SafeVault

SafeVault 是一个演示项目，用于展示如何通过安全编码实践防止常见漏洞（SQL 注入、XSS），并包含基本的认证与 RBAC 示例。

快速开始

1. 安装依赖：

```powershell
cd d:\JsProject\coursea\c5
npm install
```

2. 启动（开发）：

```powershell
npm run dev
```

3. 运行测试：

```powershell
npm test
```

说明

- `src/`：应用代码。
- `tests/`：单元测试（包括 SQL 注入与 XSS 场景的测试桩）。

配置

将数据库连接信息放到环境变量中：

```
DB_HOST=localhost
DB_USER=root
DB_PASSWORD=secret
DB_NAME=safevault
```
