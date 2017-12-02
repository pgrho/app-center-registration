## App Center Registration

Automate Visual Studio App Center invitation.

## Application Settings

### appsettings.json

- `"Site"`
  - `"OwnerName"`: Owner name registered in App Center.
  - `"AppName"`: Application name registered in App Center.
  - `"OwnerDisplayName"`: Owner name used for copyright notice.
  - `"AppDisplayName"`: Application name used for HTML.
  - `"ApiToken"`: API Token for App Center. cf https://appcenter.ms/settings/apitokens

### Environment variables

- `OWNER_NAME`
- `APP_DISPLAY_NAME`
- `OWNER_NAME`
- `APP_DISPLAY_NAME`
- `API_TOKEN`

When you use docker compose, you can specify those environment variables by creating `.env` file. Below is the example.

```
PORT=5010
API_TOKEN=xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
```
