<script lang="ts">
  import type { Snippet } from "svelte";
  import { base } from "./base";
  import { cn } from "tailwind-variants";

  type Props = {
    children: Snippet;
    class?: string;
  };

  const { children, class: className = "" }: Props = $props();
</script>

<div class="flex flex-col w-full h-full">
  {@render nav()}

  <div class={base({ className: cn("py-8 w-full h-full", className) })}>
    {@render children()}
  </div>
</div>

{#snippet nav()}
  <nav class="bg-slate-200 p-2">
    <img src="/fanoos.png" alt="" class="aspect-square w-12" />
  </nav>
{/snippet}
