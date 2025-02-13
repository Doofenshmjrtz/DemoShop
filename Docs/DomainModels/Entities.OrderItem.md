# Domain Models

## OrderItem

```csharp
class OrderItem
{
    OrderItem Create();
    void MarkAsDelivered();
    void MarkAsCancelled();
}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "AAA AAA",
  "unitPrice": 10.00,
  "quantity": 10,
  "subtotal": 100.00,
  "isDelivered": false
}
```