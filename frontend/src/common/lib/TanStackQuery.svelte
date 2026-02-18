<script lang="ts">
  import { QueryClientProvider } from "@tanstack/svelte-query";
  import { queryClient } from "./query-client";
  import type { Snippet } from "svelte";
  import { SvelteQueryDevtools } from "@tanstack/svelte-query-devtools";

  const { children }: { children: Snippet } = $props();
</script>

<QueryClientProvider client={queryClient}>
  {@render children()}
  <SvelteQueryDevtools initialIsOpen={false} />
</QueryClientProvider>
