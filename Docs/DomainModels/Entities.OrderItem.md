# Domain Models

## OrderItem

```csharp
class OrderItem
{
    OrderItem Create();
    void MarkItemAsDelivered();
}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "unitPrice": "00.00",
  "quantity": "00",
  "subtotal": "00.00",
  "isDelivered": false
}
```