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
  "orderItems": [
    {
      "id": "00000000-0000-0000-0000-000000000000",
      "unitPrice": "00.00",
      "quantity": "00",
      "subtotal": "00.00",
      "isDelivered": false
    }
  ]
}
```