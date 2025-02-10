# Domain Models

## Order

```csharp
class Order
{
    Order Create();
    void AddItem(decimal unitPrice, int quantity);
    void DeleteItem(Guid orderItemId);
    void MarkAsProcessing();
    void MarkAsDelivered(Guid orderItemId);
    void MarkAsDelivered();
    void MarkAsCanceled();
}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "orderDate": "2025-02-11T10:30:00",
  "items": [
    {
      "id": "00000000-0000-0000-0000-000000000000",
      "unitPrice": 10.00,
      "quantity": 10,
      "subtotal": 100.00,
      "isDelivered": false
    }
  ],
  "orderTotal": 100.00,
  "status": 0
}
```