# Labs Keycloak

## Use Cases and Permissions

| User Type | Role                      | Use Case                          |
|-----------|---------------------------|-----------------------------------|
| admin     | create-organization       | Create organization               |
| admin     | update-organization       | Update organization               |
| manager   | create-event              | Create event                      |
| manager   | list-ordanization-events  | List organization created events  |
| manager   | update-event              | Update event                      |
| customer  | list-events               | List Events                       |
| customer  | buy-ticket                | Buy Ticket                        |

## Restrictions

- Manager only can list his organization events
- Manager only can update his organization created events

## Users

| Username              | User Type |
|-----------------------|-----------|
| admin@email.com       | admin     |
| manager-a@email.com   | manager   |
| manager-b@email.com   | manager   |
| customer@email.com    | admin     |
