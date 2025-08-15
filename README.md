# FullStackApp

REFLECTION — InventoryHub (Copilot-Assisted)
What Copilot Helped With
Integration scaffolding: quickly generated the HttpClient logic to call /api/products and deserialize into Product[].

Error handling patterns: suggested using EnsureSuccessStatusCode(), try/catch, and proper JSON handling.

Debug updates: helped update the route to /api/productlist when the back end changed the endpoint.

CORS setup: generated a basic CORS configuration for the Minimal API.

JSON shape: produced an example response with a nested Category.

Performance hints: suggested adding IMemoryCache on the back end and a simple client-side cache in the service.

Challenges & How We Solved Them
CORS errors: resolved via app.UseCors(...AllowAnyOrigin...) (for learning purposes).

Malformed JSON: used stricter deserialization with JsonSerializerOptions plus a service wrapper.

Route mismatch: updated client calls to /api/productlist.

Redundant API calls: introduced TTL caching on the client and server-side caching.

Lessons Learned
Copilot accelerates routine work (templates, wrappers), but it’s important to review security and architecture manually.

For production, we should tighten CORS, move base URLs to configuration, expand logging, and add retries with Polly.
