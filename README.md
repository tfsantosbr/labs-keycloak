# Labs Keycloak

## Use Cases and Permissions

| User Type | Role                      | Use Case                          |
|-----------|---------------------------|-----------------------------------|
| admin     | create-organization       | Create organization               |
| admin     | list-organizations        | List created organizations        |
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
| mario@email.com       | manager   |
| sonic@email.com       | manager   |
| customer@email.com    | admin     |
